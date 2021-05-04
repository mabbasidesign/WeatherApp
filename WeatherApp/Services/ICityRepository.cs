using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    interface ICityRepository
    {
        bool CreateCity(City city);
        bool DeletHorlyWeather(City city);
        bool Save();
    }
}
