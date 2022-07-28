using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAll()
        {
            return northwindContext.Employees.ToList();
        }

        [HttpGet("GetAllEmployeesByLastName")]
        public List<Employee> GetAllEmployeesByLastName(string lastName)
        {
            return northwindContext.Employees.Where(e => e.LastName == lastName).ToList();
        }
    }
}
