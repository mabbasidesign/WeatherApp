using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    interface IDailyRepository
    {
        ICollection<Daily> GetDailyWeather();
        Daily GetDailyWeather(int id);


        bool CreateDailyWeather(Daily weatherDaily);
        bool UpdateDailyWeather(Daily weatherDaily);
        bool DeleteDailyWeather(Daily weatherDaily);
        bool Save();
    }
}
