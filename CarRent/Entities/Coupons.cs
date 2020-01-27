using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Coupons
    {
        public Coupons()
        {
            Reservations = new HashSet<Reservations>();
        }

        public string CouponCode { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
