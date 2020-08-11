using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Services
{
    public class DataServices
    {
        public static List<Product> Products { get; set; }
        public static List<Cart> Carts { get; set; }

        static DataServices()
        {
            Products = new List<Product>();
            Carts = new List<Cart>();
        }
    }
}
