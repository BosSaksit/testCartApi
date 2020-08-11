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
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return DataServices.Products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(string id)
        {
            return DataServices.Products.FirstOrDefault(it => it.ProductId == id);
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            if (product != null)
            {
                product.ProductId = Guid.NewGuid().ToString();
                DataServices.Products.Add(product);
            }
        }

        [HttpPut]
        public void EditProduct([FromBody] Product product)
        {
            var editProduct = DataServices.Products.FirstOrDefault(it => it.ProductId == product.ProductId);
            editProduct.ProductName = product.ProductName;
            editProduct.ProductDetail = product.ProductDetail;
            editProduct.ProductPrice = product.ProductPrice;
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(string id)
        {
            var productDelete = DataServices.Products.FirstOrDefault(it => it.ProductId == id);
            DataServices.Products.Remove(productDelete);
        }
    }
}
