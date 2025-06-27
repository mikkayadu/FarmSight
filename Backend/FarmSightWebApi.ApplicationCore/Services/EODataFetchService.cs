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

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class EODataFetchService : IEODataFetchService
    {
        private readonly IFieldRepository _fieldRepo;
        private readonly IEODataRepository _eoDataRepo;
        private readonly HttpClient _httpClient;
        private readonly ILogger<EODataFetchService> _logger;

        public EODataFetchService(
            IFieldRepository fieldRepo,
            IEODataRepository eoDataRepo,
            HttpClient httpClient,
            ILogger<EODataFetchService> logger)
        {
            _fieldRepo = fieldRepo;
            _eoDataRepo = eoDataRepo;
            _httpClient = httpClient;
            _logger = logger;
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
            // simplified payload builder; plug in EvalScript logic later
            return $@"
            {{
              ""input"": {{
                ""bounds"": {{
                  ""bbox"": [{bbox.minLon}, {bbox.minLat}, {bbox.maxLon}, {bbox.maxLat}]
                }},
                ""data"": [{{
                  ""type"": ""sentinel-2-l2a"",
                  ""dataFilter"": {{
                    ""timeRange"": {{
                      ""from"": ""{date:yyyy-MM-dd}T00:00:00Z"",
                      ""to"": ""{date:yyyy-MM-dd}T23:59:59Z""
                    }}
                  }}
                }}]
              }},
              ""output"": {{
                ""width"": 256,
                ""height"": 256
              }},
              ""evalscript"": ""// NDVI EvalScript here""
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
            // TODO: if your EO provider requires auth, generate and return the token here
            return "<your-access-token>";
        }
        
        private (float NDVI, float Moisture, float Rainfall, float Temperature, float Drought, float Flood) ParseIndicatorsFromResponse(string responseBody)
        {
            // TODO: replace this with real parsing logic from the JSON or GeoTIFF
            return (0.68f, 0.24f, 7.3f, 29.1f, 0.3f, 0.1f); // MOCK
        }
    }
}
