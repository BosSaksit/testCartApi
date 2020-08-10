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
        private StaticDb _db;

        public CartsController()
        {
            _db = new StaticDb();
        }

        [HttpGet]
        public List<Cart> GetAllCarts()
        {
            return _db.CartController();
        }

        [HttpGet("{id}")]
        public Cart GetCart(string id)
        {
            return _db.CartController().FirstOrDefault(it => it.Id == id);
        }

        [HttpPost]
        public void AddCart([FromBody] Cart cart)
        {
            if (cart != null)
            {
                var totalPrice = cart.products.Select(it => new
                {
                    TotalPrice = it.product.Price * it.Quantity
                })
                .Sum(it => it.TotalPrice);

                _db.CartController().Add(new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    products = cart.products,
                    Total = totalPrice,
                });

            }
        }
    }
}
