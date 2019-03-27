using System;
using System.Collections.Generic;

namespace WebAppServices.DataModels
{
    public partial class Status
    {
        public Status()
        {
            BookingHistory = new HashSet<BookingHistory>();
            Rooms = new HashSet<Rooms>();
        }

        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDetails { get; set; }

        public ICollection<BookingHistory> BookingHistory { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
    }
}
