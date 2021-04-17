using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystem.Controllers;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Models
{
    public class HotelReservationDbContext : DbContext
    {
        public HotelReservationDbContext(DbContextOptions<HotelReservationDbContext> options) : base(options)
        {

        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
