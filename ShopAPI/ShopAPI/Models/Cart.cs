using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public List<ProductList> ProductList { get; set; }
        public decimal CartTotal { get; set; }
    }
}
