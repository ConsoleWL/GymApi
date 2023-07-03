using GymApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDb.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployee(int id);

        Task<Employee> CreateEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee, int id);

        Task<Employee> DeleteEmployerById(int id);

        Task DeleteAllEmployees();
    }
}
