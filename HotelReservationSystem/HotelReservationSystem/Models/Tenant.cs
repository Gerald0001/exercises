using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
