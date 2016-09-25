using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStationAdministration.Models
{
    public class Car
    {
        public int CarID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string Make { get; set; }
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Vin number is a 17-character string")]
        public string Vin { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}