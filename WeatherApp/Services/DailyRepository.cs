using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class DailyRepository : IDailyRepository
    {
        private WeatherDbContext _db;
        public DailyRepository(WeatherDbContext db)
        {
            _db = db;
        }

        public ICollection<Daily> GetDailyWeather()
        {
            return _db.Dailies.OrderBy(x => x.Situation).ToList();
        }

        public Daily GetDailyWeather(int id)
        {
            return _db.Dailies.Where(w => w.Id == id).FirstOrDefault();
        }

        public bool CreateDailyWeather(List<int> citiesId, Daily daily)
        {
            var cities = _db.Cities
                .Where(c => citiesId.Contains(c.Id)).ToList();

            foreach(var city in cities)
            {
                var dailyCity = new DailyCity
                {
                    City = city,
                    Daily = daily
                };
                _db.Add(dailyCity);
            }

            _db.Add(daily);
            return Save();
        }

        public bool UpdateDailyWeather(List<int> citiesId, Daily daily)
        {
            var cities = _db.Cities
                .Where(c => citiesId.Contains(c.Id)).ToList();


            var dailyCitiesToDelete = _db.DailyCities
                .Where(d => d.DailyId == daily.Id);

            _db.RemoveRange(dailyCitiesToDelete);

            foreach (var city in cities)
            {
                var dailyCity = new DailyCity
                {
                    City = city,
                    Daily = daily
                };
                _db.Add(dailyCity);
            }

            _db.Update(daily);
            return Save();
        }

        public bool DeleteDailyWeather(Daily daily)
        {
            _db.Remove(daily);
            return Save();
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved >= 0 ? true : false;
        }

    }
}
