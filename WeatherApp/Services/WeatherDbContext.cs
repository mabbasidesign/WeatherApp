using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherDbContext: DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Daily> Days { get; set; }
        public virtual DbSet<Hourly> Hours { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<DailyCity> DailyCities { get; set; }
        public virtual DbSet<HourlyCity> HourlyCities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyCity>()
                        .HasKey(dc => new { dc.DailyId, dc.CityyId });
            modelBuilder.Entity<DailyCity>()
                        .HasOne(d => d.city)
                        .WithMany(dc => dc.DailyCities)
                        .HasForeignKey(d => d.CityyId);
            modelBuilder.Entity<DailyCity>()
                        .HasOne(d => d.daily)
                        .WithMany(dc => dc.DailyCities)
                        .HasForeignKey(d => d.DailyId);


            modelBuilder.Entity<HourlyCity>()
                        .HasKey(hc => new { hc.HourlyId, hc.CityyId });
            modelBuilder.Entity<HourlyCity>()
                        .HasOne(h => h.city)
                        .WithMany(hc => hc.HourlyCities)
                        .HasForeignKey(h => h.CityyId);
            modelBuilder.Entity<HourlyCity>()
                        .HasOne(h => h.hourly)
                        .WithMany(hc => hc.HourlyCities)
                        .HasForeignKey(h => h.HourlyId);
        }
    }
}
