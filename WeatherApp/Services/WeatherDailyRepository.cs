using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherDailyRepository : IWeatherDailyRepository
    {
        private WeatherDbContext _db;
        public WeatherDailyRepository(WeatherDbContext db)
        {
            _db = db;
        }

        public ICollection<Day> GetWeatherDaily()
        {
            return _db.WeatherDailys.OrderBy(x => x.Situation).ToList();
        }

        public Day GetWeatherDaily(int id)
        {
            return _db.WeatherDailys.Where(w => w.Id == id).FirstOrDefault();
        }

        public bool CreateWeatherDaily(Day weatherDaily)
        {
            _db.Add(weatherDaily);
            return Save();
        }

        public bool UpdateWeatherDaily(Day weatherDaily)
        {
            _db.Update(weatherDaily);
            return Save();
        }

        public bool DeleteWeatherDaily(Day weatherDaily)
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
