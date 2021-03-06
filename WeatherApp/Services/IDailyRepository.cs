using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IDailyRepository
    {
        ICollection<Daily> GetDailyWeathers();
        Daily GetDailyWeather(int id);

        bool CreateDailyWeather(List<int> citiesId, Daily daily);
        bool UpdateDailyWeather(List<int> citiesId, Daily daily);
        bool DeleteDailyWeather(Daily daily);
        bool Save();
    }
}
