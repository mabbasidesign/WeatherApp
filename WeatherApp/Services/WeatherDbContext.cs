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

        public virtual DbSet<Daily> WeatherDailys { get; set; }

    }
}
