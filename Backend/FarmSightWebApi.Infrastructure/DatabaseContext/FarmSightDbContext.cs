using FarmSightWebApi.ApplicationCore.Domain.Entities;
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
        public FarmSightDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<EOData> EOData { get; set; }
        public virtual DbSet<YieldForecast> YieldForecasts { get; set; }
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<CropCalendar> CropCalendars { get; set; }
        public virtual DbSet<MessageLog> MessageLogs { get; set; }
        public virtual DbSet<BenchmarkSnapshot> BenchmarkSnapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }

}
