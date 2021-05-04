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
            return _db.Days.OrderBy(x => x.Situation).ToList();
        }

        public Daily GetDailyWeather(int id)
        {
            return _db.Days.Where(w => w.Id == id).FirstOrDefault();
        }

        public bool CreateDailyWeather(Daily weatherDaily)
        {
            _db.Add(weatherDaily);
            return Save();
        }

        public bool UpdateDailyWeather(Daily weatherDaily)
        {
            _db.Update(weatherDaily);
            return Save();
        }

        public bool DeleteDailyWeather(Daily weatherDaily)
        {
            _db.Remove(weatherDaily);
            return Save();
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved >= 0 ? true : false;
        }

    }
}
