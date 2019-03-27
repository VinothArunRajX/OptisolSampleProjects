using System;
using System.Collections.Generic;

namespace WebAppServices.DataModels
{
    public partial class BookingHistory
    {
        public long BookingId { get; set; }
        public long? BookedByUserId { get; set; }
        public long? BookedRoomId { get; set; }
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public long? BookedStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MeetinName { get; set; }

        public Users BookedByUser { get; set; }
        public Rooms BookedRoom { get; set; }
        public Status BookedStatusNavigation { get; set; }
    }
}
