using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public List<ProductItem> products { get; set; }
        public decimal Total { get; set; }
    }
}
