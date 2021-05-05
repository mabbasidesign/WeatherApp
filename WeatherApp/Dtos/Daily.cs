using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Dtos
{
    public class Daily
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MinTemperaure { get; set; }
        public int MaxTemperature { get; set; }
        public string Situation { get; set; }
        public int WindSpeed { get; set; }
        public TimeSpan SunriseTime { get; set; }
        public TimeSpan SunetTime { get; set; }
        public TimeSpan LastUpdatedAt { get; set; }
    }
}
