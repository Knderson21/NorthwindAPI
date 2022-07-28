using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllCustomers")]
        public List<Customer> GetAll()
        {
            return northwindContext.Customers.ToList();
        }

        [HttpGet("GetAllCustomersByCountry")]
        public List<Customer> GetAllCustomersByCountry(string country)
        {
            return northwindContext.Customers.Where(c => c.Country == country).ToList();
        }

    }
}
