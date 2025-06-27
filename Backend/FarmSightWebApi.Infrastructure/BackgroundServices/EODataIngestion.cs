using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using FarmSightWebApi.ApplicationCore.ServiceContracts;

namespace FarmSightWebApi.Infrastructure.BackgroundServices
{
    public class EODataIngestionJob : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<EODataIngestionJob> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(30); // adjust as needed

        public EODataIngestionJob(IServiceScopeFactory scopeFactory, ILogger<EODataIngestionJob> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EO Data Ingestion Job started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var eoService = scope.ServiceProvider.GetRequiredService<IEODataFetchService>();
                    int ingested = await eoService.FetchForAllFieldsAsync(DateTime.UtcNow.Date);

                    _logger.LogInformation($"✅ EO Data ingestion complete: {ingested} fields processed on {DateTime.UtcNow:yyyy-MM-dd}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ EO Data ingestion failed.");
                }

                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("EO Data Ingestion Job stopped.");
        }
    }
}
