using System.Collections.Generic;
using System.Linq;
using EmployeeManagementAPI.Core.Entities;
using EmployeeManagementAPI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();  
        }

        public Employee GetEmployeeById(int empNo)
        {
            return _context.Employees.Find(empNo);  
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);  
            _context.SaveChanges();  
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.EmpNo);
            if (existingEmployee != null)
            {
                _context.Entry(existingEmployee).CurrentValues.SetValues(employee);  
                _context.SaveChanges();  
            }
        }

        public void DeleteEmployee(int empNo)
        {
            var employee = GetEmployeeById(empNo);
            if (employee != null)
            {
                _context.Employees.Remove(employee);  
                _context.SaveChanges();  
            }
        }
    }
}
