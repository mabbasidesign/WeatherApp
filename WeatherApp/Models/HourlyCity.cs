using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class HourlyCity
    {
        public int HourlyId { get; set; }
        public Hourly hourly { get; set; }

        public int CityyId { get; set; }
        public City city { get; set; }
    }
}
