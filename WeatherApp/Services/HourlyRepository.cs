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
            return _db.Hourlies.OrderBy(h => h.Id).ToList();
        }

        public Hourly GetWeatherDaily(int id)
        {
            return _db.Hourlies.Where(h => h.Id == id).FirstOrDefault();
        }

        public bool CreateHorlyWeather(List<int> citiesId, Hourly hourly)
        {
            var cities = _db.Cities
                .Where(c => citiesId.Contains(c.Id)).ToList();

            foreach (var city in cities)
            {
                var hourlyCity = new HourlyCity
                {
                    City = city,
                    Hourly = hourly
                };
                _db.Add(hourlyCity);
            }

            _db.Add(hourly);
            return Save();
        }

        public bool UpdateHorlyWeather(List<int> citiesId, Hourly hourly)
        {
            var cities = _db.Cities
                .Where(c => citiesId.Contains(c.Id)).ToList();

            var hourlyCitiesToDelete = _db.HourlyCities
                .Where(h => h.HourlyId == hourly.Id);

            _db.RemoveRange(hourlyCitiesToDelete);

            foreach (var city in cities)
            {
                var hourlyCity = new HourlyCity
                {
                    City = city,
                    Hourly = hourly
                };
                _db.Add(hourlyCity);
            }

            _db.Add(hourly);
            return Save();
        }

        public bool DeletHorlyWeather(Hourly hourly)
        {
            _db.Remove(hourly);
            return Save();
        }
        
        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved >= 0 ? true : false;
        }
        
    }
}
