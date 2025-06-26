using FamSightWebApi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.Infrastructure.DatabaseContext
{
    public class FarmSightDbContext : DbContext
    {
        public FarmSightDbContext(DbContextOptions<FarmSightDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<EOData> EOData { get; set; }
        public DbSet<YieldForecast> YieldForecasts { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<CropCalendar> CropCalendars { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<BenchmarkSnapshot> BenchmarkSnapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Farmer
            modelBuilder.Entity<Farmer>().ToTable("Farmers");

            // Field
            modelBuilder.Entity<Field>().ToTable("Fields");

            // EOData
            modelBuilder.Entity<EOData>().ToTable("EOData");

            // Yield Forecast
            modelBuilder.Entity<YieldForecast>().ToTable("Yield_Forecasts");

            // Alerts
            modelBuilder.Entity<Alert>().ToTable("Alerts");

            // Crop Calendar
            modelBuilder.Entity<CropCalendar>().ToTable("CropCalendars");

            // Message Log
            modelBuilder.Entity<MessageLog>().ToTable("Message_Logs");

            // Benchmark Snapshot
            modelBuilder.Entity<BenchmarkSnapshot>().ToTable("Benchmark_Snapshots");

            base.OnModelCreating(modelBuilder);
        }
    }

}
