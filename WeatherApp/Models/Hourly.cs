using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Hourly
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }

        public virtual City City { get; set; }
    }
}
