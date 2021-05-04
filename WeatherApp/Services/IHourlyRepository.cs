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


        bool CreateHorlyWeather(IHourlyRepository weatherDaily);
        bool UpdateHorlyWeather(Hourly weatherDaily);
        bool DeletHorlyWeather(Hourly weatherDaily);
        bool Save(); 
    }
}
