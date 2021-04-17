using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNo { get; set; }
        public int RoomFloor { get; set; }
        public string RoomType { get; set; }
        public List<Tenant> Tenants { get; set; }
    }
}
