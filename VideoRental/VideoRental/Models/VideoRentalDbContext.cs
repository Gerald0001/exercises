using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VideoRental.Models
{
    public class VideoRentalDbContext : DbContext
    {
        public VideoRentalDbContext(DbContextOptions<VideoRentalDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRent> CustomersRents { get; set; }

    }
}
