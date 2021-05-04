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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int MinTemperaure { get; set; }

        [Required]
        public int MaxTemperature { get; set; }
        public string Situation { get; set; }
        public int WindSpeed { get; set; }
        public TimeSpan SunriseTime { get; set; }
        public TimeSpan SunetTime { get; set; }

        public virtual City City { get; set; }
    }
}
