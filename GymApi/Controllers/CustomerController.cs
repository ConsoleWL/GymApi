using GymApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Test());
        }

        public static List<Customer> Test()
        {
            return new List<Customer>
            {
                new Customer("Nikita", "Sokolov", 31),
                new Customer("Nikita", "Petrov", 32),
                new Customer("Nikita", "Asimov", 33)
            };
        }
    }
}
