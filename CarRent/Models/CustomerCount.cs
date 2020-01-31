using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class CustomerCount
    {
        [Key]
        [DisplayName("Costumer Name")]
        public string Name { get; set; }

        [DisplayName("Number of rents")]
        public int Total { get; set; }




    }
}
