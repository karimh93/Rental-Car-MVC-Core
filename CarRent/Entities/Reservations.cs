using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Reservations
    {
        public int CarId { get; set; }
        public int CostumerId { get; set; }
        public byte ReservStatsId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string CouponCode { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Customers Costumer { get; set; }
        public virtual Coupons CouponCodeNavigation { get; set; }
        public virtual ReservationStatuses ReservStats { get; set; }
    }
}
