using ShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.LocalDB
{
    public class StaticDb
    {
        public static List<Product> products { get; set; }
        public static List<Cart> carts { get; set; }

        public List<Product> ProductCollection()
        {
            if (products == null)
            {
                return new List<Product>();
            }
            return products;
        }

        public List<Cart> CartController()
        {
            if (carts == null)
            {
                return new List<Cart> { new Cart { ProductList = new List<ProductList>() } };
            }
            return carts;
        }
    }
}
