using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Dtos
{
    public class Hourly
    {
        public int Id { get; set; }
        public int Temperature { get; set; }
        public float Humidity { get; set; }
        public int WindSpeed { get; set; }
    }
}
