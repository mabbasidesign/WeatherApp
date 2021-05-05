using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Daily
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(-60, 60)]
        public int MinTemperaure { get; set; }

        [Required]
        [Range(-50, 60)]
        public int MaxTemperature { get; set; }
        public string Situation { get; set; }
        public int WindSpeed { get; set; }
        public TimeSpan SunriseTime { get; set; }
        public TimeSpan SunetTime { get; set; }
        public TimeSpan LastUpdatedAt { get; set; }

        public virtual ICollection<DailyCity> DailyCities { get; set; }


        //public int CityId { get; set; }

        //[ForeignKey("CityId")]
        //public City City { get; set; }
    }
}
