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
    public class ProductsController : ControllerBase
    {
        private StaticDb _db;

        public ProductsController()
        {
            _db = new StaticDb();
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _db.ProductCollection();
        }

        [HttpGet("{id}")]
        public Product GetProduct(string id)
        {
            return _db.ProductCollection().FirstOrDefault(it => it.Id == id);
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            if (product != null)
            {
                product.Id = Guid.NewGuid().ToString();
                _db.ProductCollection().Add(product);
            }
        }

        [HttpPut]
        public void EditProduct([FromBody] Product product)
        {
            var editProduct = _db.ProductCollection().FirstOrDefault(it => it.Id == product.Id);
            editProduct.Name = product.Name;
            editProduct.Detail = editProduct.Detail;
            editProduct.Price = product.Price;
        }

        [HttpDelete]
        public void DeleteProduct(string id)
        {
            var productDelete = _db.ProductCollection().FirstOrDefault(it => it.Id == id);
            _db.ProductCollection().Remove(productDelete);

        }
    }
}
