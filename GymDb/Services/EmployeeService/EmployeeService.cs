using GymApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDb.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly GymDbContext _gymDbContext;
        public EmployeeService(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _gymDbContext.AddAsync(employee);
            await _gymDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteAllEmployees()
        {
            var range = _gymDbContext.Employees.ToList();
            _gymDbContext.Employees.RemoveRange(range);
            await _gymDbContext.SaveChangesAsync();
        }

        public async Task<Employee> DeleteEmployerById(int id)
        {
            _gymDbContext.Employees.Remove(await _gymDbContext.Employees.FindAsync(id));
            await _gymDbContext.SaveChangesAsync();

            return await _gymDbContext.Employees.FindAsync(id);

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _gymDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = await _gymDbContext.Employees.FindAsync(id);
            if (employee == null)
                return null;
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee, int id)
        {
            Employee emp = await _gymDbContext.Employees.FindAsync(id);
            if(emp == null)
                return null;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Salary = employee.Salary;
            await _gymDbContext.SaveChangesAsync();

            return emp;
        }
    }
}
