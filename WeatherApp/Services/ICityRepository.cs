using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface ICityRepository
    {
        ICollection<City> GetCities();
        City GetCity(int id);

        bool CreateCity(City city);
        bool UpdateCity(City city);
        bool DeleteCity(City city);
        bool Save();
    }
}
