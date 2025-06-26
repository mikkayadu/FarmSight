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
            modelBuilder.Entity<Farmer>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Farmer>()
                .HasMany(u => u.Fields)
                .WithOne(f => f.Farmer)
                .HasForeignKey(f => f.UserId);

            // Field
            modelBuilder.Entity<Field>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Field>()
                .Property(f => f.Geometry)
                .HasColumnType("geometry (polygon, 4326)");

            modelBuilder.Entity<Field>()
                .Property(f => f.Location)
                .HasColumnType("geometry (point, 4326)");

            modelBuilder.Entity<Field>()
                .HasOne(f => f.CropCalendar)
                .WithOne(c => c.Field)
                .HasForeignKey<CropCalendar>(c => c.FieldId);

            // EOData
            modelBuilder.Entity<EOData>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<EOData>()
                .HasOne(e => e.Field)
                .WithMany(f => f.EOData)
                .HasForeignKey(e => e.FieldId);

            // Yield Forecast
            modelBuilder.Entity<YieldForecast>()
                .HasKey(y => y.Id);

            modelBuilder.Entity<YieldForecast>()
                .HasOne(y => y.Field)
                .WithMany(f => f.YieldForecasts)
                .HasForeignKey(y => y.FieldId);

            // Alerts
            modelBuilder.Entity<Alert>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Alert>()
                .HasOne(a => a.Field)
                .WithMany(f => f.Alerts)
                .HasForeignKey(a => a.FieldId);

            // Crop Calendar
            modelBuilder.Entity<CropCalendar>()
                .HasKey(c => c.Id);

            // Message Log
            modelBuilder.Entity<MessageLog>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<MessageLog>()
                .HasOne(m => m.Farmer)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<MessageLog>()
                .HasOne(m => m.Field)
                .WithMany()
                .HasForeignKey(m => m.FieldId)
                .IsRequired(false);

            // Benchmark Snapshot
            modelBuilder.Entity<BenchmarkSnapshot>()
                .HasKey(b => b.Id);

            base.OnModelCreating(modelBuilder);
        }
    }

}
