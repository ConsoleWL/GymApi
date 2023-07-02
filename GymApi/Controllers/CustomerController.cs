using GymApi.Models;
using GymApi.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class CustomerController : ControllerBase
    {
        private readonly ICustomerService _ICustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _ICustomerService = customerService;
        }

        // GET: api/customer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ICustomerService.GetAllCustomers());
        }

        //[HttpGet("{id}")]
        //public IActionResult GetCustomerById(int id)
        //{
        //    Customer customer = customers.SingleOrDefault(p => p.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customer);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteCustomer(int id)
        //{
        //    Customer customer = customers.SingleOrDefault(p => p.Id == id);
        //    customers.Remove(customer);

        //    return Ok("Successfully deleted customer");
        //}

        //[HttpDelete]
        //public IActionResult DeleteCustomers()
        //{
        //    customers.Clear();

        //    return Ok("Successfuly deleted customers");
        //}


        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer newCustomer)
        {
            _ICustomerService.CreateCustomer(newCustomer);

            return Ok(newCustomer);

        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateCustomer([FromBody] Customer customer, int id)
        //{
        //    //Customer customer = customers.SingleOrDefault(p => p.Id == id);
        //    Customer cst = customers.SingleOrDefault(p => p.Id == id);

        //    if(cst == null)
        //    {
        //        return NotFound();
        //    }

        //    cst.FirstName = customer.FirstName;
        //    cst.LastName = customer.LastName;
        //    cst.Age = customer.Age;

        //    return Ok(cst);
        //}

    }
}
