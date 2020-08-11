using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Services;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        public CartsController()
        {
        }

        [HttpGet]
        public List<Cart> GetAllCarts()
        {
            return DataServices.Carts;
        }

        [HttpGet("{id}")]
        public Cart GetCart(string id)
        {
            return DataServices.Carts.FirstOrDefault(it => it.CartId == id);
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

                DataServices.Carts.Add(new Cart
                {
                    CartId = Guid.NewGuid().ToString(),
                    ProductList = cart.ProductList,
                    CartTotal = totalPrice,
                });
            }
        }

        [HttpDelete]
        public void DeleteCart(string id)
        {
            var cartDelete = DataServices.Carts.FirstOrDefault(it => it.CartId == id);
            DataServices.Carts.Remove(cartDelete);
        }
    }
}
