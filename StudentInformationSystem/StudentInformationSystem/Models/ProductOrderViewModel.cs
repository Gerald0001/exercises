using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    public class ProductOrderViewModel
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
    }
}
