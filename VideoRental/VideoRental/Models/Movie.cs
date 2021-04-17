using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; } 
    }
}