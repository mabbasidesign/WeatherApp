using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class DailyCity
    {
        public int DailyId { get; set; }
        public Daily daily { get; set; }

        public int CityyId { get; set; }
        public City city { get; set; }
    }
}
