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

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = _ICustomerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = _ICustomerService.DeleteCustomerById(id);
            if (customer == null)
                return NotFound("Could not find customer");
            return Ok("Successfully deleted customer");
        }

        [HttpDelete]
        public IActionResult DeleteCustomers()
        {
            _ICustomerService.DeleteAllCustomers();

            return Ok("Successfuly deleted customers");
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer newCustomer)
        {
            _ICustomerService.CreateCustomer(newCustomer);

            return Ok(newCustomer);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromBody] Customer customer, int id)
        {

            Customer cst = _ICustomerService.UpdateCustomer(customer, id);

            if (cst == null)
            {
                return NotFound();
            }

            return Ok(cst);
        }

    }
}
