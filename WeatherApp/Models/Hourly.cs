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
        public int Id { get; set; }

        [Required]
        [Range(-50, 60)]
        public int Temperature { get; set; }
        public float Humidity { get; set; }
        public int WindSpeed { get; set; }

        public virtual ICollection<HourlyCity> HourlyCities { get; set; }


        //public int CityId { get; set; }

        //[ForeignKey("CityId")]
        //public City City { get; set; }
    }
}
