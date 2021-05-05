using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class DailyCity
    {
        public int DailyId { get; set; }
        public Daily Daily { get; set; }

        public int CityyId { get; set; }
        public City City { get; set; }
    }
}
