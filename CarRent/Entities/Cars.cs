using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Cars
    {
        public Cars()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int CarId { get; set; }
        public string Plate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
