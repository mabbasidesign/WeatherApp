using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class CityRepository : ICityRepository
    {
        private WeatherDbContext _db;
        public CityRepository(WeatherDbContext db)
        {
            _db = db;
        }

        public bool CreateCity(City city)
        {
            throw new NotImplementedException();
        }

        public bool DeletHorlyWeather(City city)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
