using System;
using System.Collections.Generic;

namespace WebAppServices.DataModels
{
    public partial class Users
    {
        public Users()
        {
            BookingHistory = new HashSet<BookingHistory>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<BookingHistory> BookingHistory { get; set; }
    }
}
