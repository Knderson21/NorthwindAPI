using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllProducts")]
        public List<Product> GetAll()
        {
            return northwindContext.Products.ToList();
        }

        [HttpGet("GetByUnitPrice")]
        public List<Product> GetByUnitPrice(decimal productPrice)
        {
            return northwindContext.Products.Where(x => x.UnitPrice == productPrice).ToList();
        }

        [HttpPost("AddProduct")]
        public Product AddProduct(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            Product newProduct = new Product()
            {
                ProductName = productName,
                SupplierId = supplierID,
                CategoryId = categoryID,
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                Discontinued = discontinued
            };
            northwindContext.Products.Add(newProduct);
            northwindContext.SaveChanges();
            return newProduct;
        }
    }
}
