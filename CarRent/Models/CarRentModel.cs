using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class CarRentModel
    {
        
        public int CarRentID { get; set; }

        [Required]
        [DisplayName("Client ID")]
        public int ClientID { get; set; }

        [Required]
        [DisplayName("Car Model")]
        public string CarModel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public string City { get; set; }



    }
}
