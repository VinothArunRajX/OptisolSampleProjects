using System;
using System.Collections.Generic;

namespace WebAppServices.DataModels
{
    public partial class Rooms
    {
        public Rooms()
        {
            BookingHistory = new HashSet<BookingHistory>();
        }

        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public long? RoomStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Status RoomStatusNavigation { get; set; }
        public ICollection<BookingHistory> BookingHistory { get; set; }
    }
}
