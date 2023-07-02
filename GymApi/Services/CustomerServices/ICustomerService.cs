using GymApi.Models;

namespace GymApi.Services.CustomerServices
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomer(int id);

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer, int id);

        Customer DeleteCustomerById(int id);

    }
}
