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
        public async Task<IActionResult> Get()
        {
            return Ok(await _ICustomerService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await _ICustomerService.GetCustomer(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return Ok(await _ICustomerService.DeleteCustomerById(id));
        }

        [HttpDelete]
        public  async Task<IActionResult> DeleteCustomers()
        {
            await _ICustomerService.DeleteAllCustomers();

            return Ok("Successfuly deleted customers");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer newCustomer)
        {
            var result = await _ICustomerService.CreateCustomer(newCustomer);

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer, int id)
        {

            Customer cst = await _ICustomerService.UpdateCustomer(customer, id);

            if (cst == null)
            {
                return NotFound();
            }

            return Ok(cst);
        }

    }
}
