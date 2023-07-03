using GymApi.Models;
using GymDb;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly GymDbContext _gymDbContext;

        public CustomerService(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _gymDbContext.AddAsync(customer);
            await _gymDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomerById(int id)
        {
            Customer customer = await _gymDbContext.Customers.FindAsync(id);
            if (customer == null)
                return null;
            _gymDbContext.Customers.Remove(customer);
            await _gymDbContext.SaveChangesAsync();

            return customer;

        }

        public async Task DeleteAllCustomers()
        {
            var range = _gymDbContext.Customers.ToList();
            _gymDbContext.Customers.RemoveRange(range);
            await _gymDbContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _gymDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await _gymDbContext.Customers.FindAsync(id);
            if (customer == null)
                return null;

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer, int id)
        {
            Customer cst = await _gymDbContext.Customers.FindAsync(id);
            if (cst == null)
                return null;

            cst.FirstName = customer.FirstName;
            cst.LastName = customer.LastName;
            cst.Age = customer.Age;

            await _gymDbContext.SaveChangesAsync();

            return cst;
        }
    }
}
