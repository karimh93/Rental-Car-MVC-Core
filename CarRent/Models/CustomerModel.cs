using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class CustomerModel
    {
        [Required]
        [DisplayName("Client ID")]
        public int CostumerId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        
        [DisplayName("ZIP Code")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required]
        [DisplayName("Location")]
        public string Location { get; set; }

    }
}
