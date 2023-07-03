using GymApi.Models;

namespace GymApi.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomer(int id);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> UpdateCustomer(Customer customer, int id);

        Task<Customer> DeleteCustomerById(int id);

        Task DeleteAllCustomers();

    }
}
