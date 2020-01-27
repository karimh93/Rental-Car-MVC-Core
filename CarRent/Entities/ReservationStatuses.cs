using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class ReservationStatuses
    {
        public ReservationStatuses()
        {
            Reservations = new HashSet<Reservations>();
        }

        public byte ReservStatsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
