using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "City Name Name cannot be more than 50 characters")]
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Daily> Days { get; set; }
        public virtual ICollection<Hourly> Hours { get; set; }
    }
}
