using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; // Add this

using System.IO;

namespace FarmSightWebApi.Infrastructure.DatabaseContext
{
    public class FarmSightDbContextFactory : IDesignTimeDbContextFactory<FarmSightDbContext>
    {
        public FarmSightDbContext CreateDbContext(string[] args)
        {
            // Build configuration from the startup project
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FarmSightWebApi.UI"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FarmSightDbContext>();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }

            optionsBuilder.UseNpgsql(connectionString);

            return new FarmSightDbContext(optionsBuilder.Options);
        }
    }
}