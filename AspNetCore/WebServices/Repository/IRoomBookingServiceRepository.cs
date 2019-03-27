using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppServices.DataModels;
using WebAppServices.DTO;

namespace WebAppServices.Repository
{
    /// <summary>
    /// IBookingService
    /// </summary>
    public interface IRoomBookingServiceRepository : IDisposable
    { 

        DtoRooms GetAllRooms();

        DtoRooms GetAvialableRoom(string bookIn, string bookOut, int currentPage, int pageSize);

        int SaveUser(DtoUser objUsers);
    }
}
