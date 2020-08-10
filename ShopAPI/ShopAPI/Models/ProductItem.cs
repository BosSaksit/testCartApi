using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class ProductItem
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
