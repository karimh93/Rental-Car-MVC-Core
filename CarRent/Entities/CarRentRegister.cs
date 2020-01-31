using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class CarRentRegister
    {
        public int CarRentId { get; set; }
        public int ClientId { get; set; }
        public string CarModel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
    }
}
