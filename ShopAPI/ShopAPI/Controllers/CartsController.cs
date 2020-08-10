using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.LocalDB;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        public static List<Cart> carts = new List<Cart> { };
        public CartsController()
        {
        }

        [HttpGet]
        public List<Cart> GetAllCarts()
        {
            return carts;
        }

        [HttpGet("{id}")]
        public Cart GetCart(string id)
        {
            return carts.FirstOrDefault(it => it.CartId == id);
        }

        [HttpPost]
        public void AddCart([FromBody] Cart cart)
        {
            if (cart != null)
            {
                var totalPrice = cart.ProductList.Select(it => new
                {
                    TotalPrice = it.product.ProductPrice * it.ProductQuantity
                })
                .Sum(it => it.TotalPrice);

                carts.Add(new Cart
                {
                    CartId = Guid.NewGuid().ToString(),
                    ProductList = cart.ProductList,
                    CartTotal = totalPrice,
                });

            }
        }
    }
}
