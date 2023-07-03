using GymApi.Models;

namespace GymApi.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        static List<Customer> customers = new List<Customer>(new[] {
                new Customer(){Id = 1, FirstName = "Nikita", LastName = "Sokolov", Age= 35},
                new Customer(){Id = 2, FirstName = "Nikita", LastName = "Petrov", Age= 45},
                new Customer(){Id = 3, FirstName = "Nikita", LastName = "Skvorcov", Age= 25}
        });

        public CustomerService()
        {
            
        }

        public Customer CreateCustomer(Customer customer)
        {
            customers.Add(customer);

            return customer;
        }

        public Customer DeleteCustomerById(int id)
        {
            Customer customer = customers.SingleOrDefault(c => c.Id == id);
            customers.Remove(customer);
            return customer;
        }
        public void DeleteAllCustomers()
        {
            customers.Clear();
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = customers.SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public Customer UpdateCustomer(Customer customer, int id)
        {
            Customer customer1 = customers.SingleOrDefault(c => c.Id == id);

            customer1.FirstName = customer.FirstName;
            customer1.LastName = customer.LastName;
            customer1.Age = customer.Age;

            return customer1;
        }
    }
}
