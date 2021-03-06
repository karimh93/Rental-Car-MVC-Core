﻿using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int CostumerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
