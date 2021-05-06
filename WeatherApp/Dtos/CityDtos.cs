using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Dtos
{
    public class CityDtos
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ZipCode { get; set; }
    }
}
