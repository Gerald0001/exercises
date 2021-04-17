﻿using System;

namespace VideoRental.Models
{
    public class CustomerRent
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        
    }
}
