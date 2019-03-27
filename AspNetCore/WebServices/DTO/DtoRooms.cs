using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServices.DTO
{
    public class DtoRooms
    {
        public DtoRooms()
        {
            this.Rooms = new List<DataModels.Rooms>();
        }

        public int Total { get; set; }
        public List<DataModels.Rooms> Rooms { get; set; }
    }
}
