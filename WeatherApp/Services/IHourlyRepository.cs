using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    interface IHourlyRepository
    {
        ICollection<Hourly> GetHorlyWeather();
        Hourly GetWeatherDaily(int id);

        bool CreateHorlyWeather(List<int> citiesId, Hourly hourly);
        bool UpdateHorlyWeather(List<int> citiesId, Hourly hourly);
        bool DeletHorlyWeather(Hourly hourly);
        bool Save(); 
    }
}
