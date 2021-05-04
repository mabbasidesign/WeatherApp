using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    interface IDailyRepository
    {
        ICollection<Daily> GetWeatherDaily();
        Daily GetWeatherDaily(int id);


        bool CreateWeatherDaily(Daily weatherDaily);
        bool UpdateWeatherDaily(Daily weatherDaily);
        bool DeleteWeatherDaily(Daily weatherDaily);
        bool Save();
    }
}
