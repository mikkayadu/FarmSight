using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class EODataFetchService : IEODataFetchService
    {
        private readonly IFieldRepository _fieldRepo;
        private readonly IEODataRepository _eoDataRepo;
        private readonly HttpClient _httpClient;
        private readonly ILogger<EODataFetchService> _logger;
        private readonly IConfiguration _config;

        public EODataFetchService(
            IFieldRepository fieldRepo,
            IEODataRepository eoDataRepo,
            HttpClient httpClient,
            ILogger<EODataFetchService> logger, IConfiguration configuration)
        {
            _fieldRepo = fieldRepo;
            _eoDataRepo = eoDataRepo;
            _httpClient = httpClient;
            _logger = logger;
            _config = configuration;
        }

        public async Task<bool> FetchAndSaveEODataForFieldAsync(Guid fieldId, DateTime date)
        {
            var field = await _fieldRepo.GetByIdAsync(fieldId);
            if (field == null) return false;

            var bbox = GetBoundingBox(field);
            var requestJson = BuildEORequestJson(bbox, date);
            var accessToken = await GetTokenAsync(); // if required

            var request = new HttpRequestMessage(HttpMethod.Post, "https://services.sentinel-hub.com/api/v1/process");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Content = new StringContent(requestJson);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to fetch EO data for Field: {fieldId}, Status: {response.StatusCode}");
                return false;
            }
            Console.Write(response);
            var body = await response.Content.ReadAsStringAsync();
            var parsed = ParseIndicatorsFromResponse(body); // implement this

            var eoData = new EOData
            {
                Id = Guid.NewGuid(),
                FieldId = fieldId,
                Timestamp = date,
                NDVI = parsed.NDVI,
                SoilMoisture = parsed.Moisture,
                Rainfall = parsed.Rainfall,
                Temperature = parsed.Temperature,
                DroughtIndex = parsed.Drought,
                FloodRisk = parsed.Flood
            };

            await _eoDataRepo.AddAsync(eoData);
            return true;
        }

        public async Task<int> FetchForAllFieldsAsync(DateTime date)
        {
            var fields = await _fieldRepo.GetAllAsync();
            int success = 0;

            foreach (var field in fields)
            {
                if (await FetchAndSaveEODataForFieldAsync(field.Id, date))
                    success++;
            }

            return success;
        }

        private string BuildEORequestJson((double minLon, double minLat, double maxLon, double maxLat) bbox, DateTime date)
        {
            var fromDate = date.ToString("yyyy-MM-ddT00:00:00Z");
            var toDate = date.ToString("yyyy-MM-ddT23:59:59Z");

            return $@"{{
      ""input"": {{
        ""bounds"": {{
          ""bbox"": [{bbox.minLon}, {bbox.minLat}, {bbox.maxLon}, {bbox.maxLat}],
          ""properties"": {{
            ""crs"": ""http://www.opengis.net/def/crs/OGC/1.3/CRS84""
          }}
        }},
        ""data"": [
          {{
            ""type"": ""sentinel-2-l2a"",
            ""dataFilter"": {{
              ""timeRange"": {{
                ""from"": ""{fromDate}"",
                ""to"": ""{toDate}""
              }}
            }}
          }}
        ]
      }},
      ""output"": {{
        ""width"": 256,
        ""height"": 256,
        ""responses"": [{{ ""identifier"": ""default"", ""format"": {{ ""type"": ""image/png"" }} }}]
      }},
      ""evalscript"": ""//VERSION=3\nfunction setup() {{\n  return {{\n    input: [\""B04\"", \""B08\""],\n    output: {{ bands: 1 }}\n  }};\n}}\n\nfunction evaluatePixel(sample) {{\n  let ndvi = (sample.B08 - sample.B04) / (sample.B08 + sample.B04);\n  return [ndvi];\n}}""
    }}";
        }



        private (double minLon, double minLat, double maxLon, double maxLat) GetBoundingBox(Field f)
        {
            var lats = new[] { f.Lat1, f.Lat2, f.Lat3, f.Lat4 };
            var lngs = new[] { f.Lng1, f.Lng2, f.Lng3, f.Lng4 };
            return (lngs.Min(), lats.Min(), lngs.Max(), lats.Max());
        }

        private async Task<string> GetTokenAsync()
        {
            var clientId = _config.GetRequiredSection("SentinelHub:ClientId").Value;
            var clientSecret = _config.GetRequiredSection("SentinelHub:ClientSecret").Value;

            var request = new HttpRequestMessage(HttpMethod.Post, "https://services.sentinel-hub.com/oauth/token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "client_credentials",
                    ["client_id"] = clientId,
                    ["client_secret"] = clientSecret
                })
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var root = JsonDocument.Parse(json).RootElement;
            Console.Write(root.GetProperty("access_token").GetString());
            return root.GetProperty("access_token").GetString();
        }


        private (float NDVI, float Moisture, float Rainfall, float Temperature, float Drought, float Flood) ParseIndicatorsFromResponse(string responseBody)
        {
            var json = JsonDocument.Parse(responseBody).RootElement;
            var ndvi = json.GetProperty("data")[0]
                           .GetProperty("outputs")
                           .GetProperty("default")
                           .GetProperty("bands")
                           .GetProperty("ndvi")
                           .GetProperty("stats")
                           .GetProperty("mean")
                           .GetSingle();

            return (
                NDVI: ndvi,
                Moisture: 0.25f,
                Rainfall: 5.2f,
                Temperature: 27.0f,
                Drought: 0.1f,
                Flood: 0.0f
            );
        }

    }
}
