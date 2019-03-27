using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebAppServices.DataModels;
using WebAppServices.DTO;

namespace WebAppServices.Repository
{
    public class RoomBookingServiceRepository : IRoomBookingServiceRepository
    {
        public ConferenceRoomBookingContext ConferenceRoomBookingContext { get; set; }

        public RoomBookingServiceRepository()
        {
            ConferenceRoomBookingContext = new ConferenceRoomBookingContext();
        }
        public DtoRooms GetAllRooms()
        {
            DataModels.ConferenceRoomBookingContext context = ConferenceRoomBookingContext;
            var objRooms = context.Rooms;
            DtoRooms room = new DtoRooms();
            room.Rooms = objRooms.ToList();
            room.Total = context.Rooms.Count();
            return room;
        }

        public int SaveUser(DtoUser objUsers)
        {
            DataModels.ConferenceRoomBookingContext context = ConferenceRoomBookingContext;
            if (context.Users.Any(x => x.EmailId.ToLower() == objUsers.EmailId.ToLower()))
                return 0;

            Users newUser = new Users();
            newUser.UserName = objUsers.UserName;
            newUser.EmailId = objUsers.EmailId;
            newUser.Status = true;
            context.Users.Add(newUser);
            context.Entry(newUser).State = EntityState.Added;
           int state= context.SaveChanges();

            return state;
             
        }

        public DtoRooms GetAvialableRoom(string bookIn, string bookOut, int currentPage, int pageSize)
        {
            DtoRooms room = new DtoRooms();
            
           
            List<DataModels.Rooms> objRooms = new List<Rooms>();

            using (var connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=ConferenceRoomBooking;Trusted_Connection=True;"))
            {
                using (var command = new SqlCommand("sp_CheckRoomAvialable", connection)
                { CommandType = CommandType.StoredProcedure })
                {

                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.Add(new SqlParameter("@BookingTimeIn", Convert.ToDateTime(String.Format("{0:MM/dd/yyyy HH:mm:ss}", bookIn.Trim()), CultureInfo.CurrentCulture)));
                    command.Parameters.Add(new SqlParameter("@BookingTimeOut", Convert.ToDateTime(String.Format("{0:MM/dd/yyyy HH:mm:ss}", bookOut.Trim()), CultureInfo.CurrentCulture)));
                    connection.Open();
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());

                    objRooms = (from DataRow row in dt.Rows
                                select new Rooms
                                {
                                    RoomId = (long)row["RoomId"],
                                    RoomName = (string)row["RoomName"],
                                    RoomStatus = (long)row["RoomStatus"]
                                }).ToList();

                    room.Total = dt.Rows.Count;
                    room.Rooms = objRooms.ToList();
                    connection.Close();
                }
            }
          
            return room;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BookingService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
