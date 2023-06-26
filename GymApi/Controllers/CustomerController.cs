using GymApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        List<Customer> customers = new List<Customer>( new[] {
                new Customer(){Id = 1, FirstName = "Nikita", LastName = "Sokolov", Age= 35},
                new Customer(){Id = 2, FirstName = "Nikita", LastName = "Petrov", Age= 45},
                new Customer(){Id = 3, FirstName = "Nikita", LastName = "Skvorcov", Age= 25}
        });

        

        // GET: api/customer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = customers.SingleOrDefault(p => p.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = customers.SingleOrDefault(p => p.Id == id);
            customers.Remove(customer);

            return Ok("Succefully deleted customer");
        }

        //[HttpPost]
        //public IActionResult CreateCustomer([FromBody] Customer newCustomer)
        //{
        //    customers.Add(newCustomer);

        //    return Created;
        //}

    }
}
