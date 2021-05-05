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
            _db.Add(city);
            return Save();
        }

        public bool DeletHorlyWeather(City city)
        {
            _db.Remove(city);
            return Save();
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
