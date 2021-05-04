using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class HourlyRepository : IHourlyRepository
    {
        private WeatherDbContext _db;
        public HourlyRepository(WeatherDbContext db)
        {
            _db = db;
        }

        public ICollection<Hourly> GetHorlyWeather()
        {
            throw new NotImplementedException();
        }

        public Hourly GetWeatherDaily(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateHorlyWeather(Hourly weatherDaily)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHorlyWeather(Hourly weatherDaily)
        {
            throw new NotImplementedException();
        }

        public bool DeletHorlyWeather(Hourly weatherDaily)
        {
            throw new NotImplementedException();
        }
        
        public bool Save()
        {
            throw new NotImplementedException();
        }
        
    }
}
