using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    interface IWeatherDailyRepository
    {
        ICollection<Day> GetWeatherDaily();
        Day GetWeatherDaily(int id);


        bool CreateWeatherDaily(Day weatherDaily);
        bool UpdateWeatherDaily(Day weatherDaily);
        bool DeleteWeatherDaily(Day weatherDaily);
        bool Save();
    }
}
