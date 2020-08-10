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
        public static List<Product> products = new List<Product>{};

        public ProductsController()
        {
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(string id)
        {
            return products.FirstOrDefault(it => it.ProductId == id);
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            product.ProductId = Guid.NewGuid().ToString();
            products.Add(product);
        }

        [HttpPut]
        public void EditProduct([FromBody] Product product)
        {
            var editProduct = products.FirstOrDefault(it => it.ProductId == product.ProductId);
            editProduct.ProductName = product.ProductName;
            editProduct.ProductDetail = editProduct.ProductDetail;
            editProduct.ProductPrice = product.ProductPrice;
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(string id)
        {
            var productDelete = products.FirstOrDefault(it => it.ProductId == id);
            products.Remove(productDelete);

        }
    }
}
