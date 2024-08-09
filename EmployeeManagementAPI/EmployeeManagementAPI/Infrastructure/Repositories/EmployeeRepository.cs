using System.Collections.Generic;
using EmployeeManagementAPI.Core.Entities;
using EmployeeManagementAPI.Core.Interfaces;

namespace EmployeeManagementAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeeById(int empNo)
        {
            return _employees.Find(e => e.EmpNo == empNo);
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.EmpNo);
            if (existingEmployee != null)
            {
                // Implement update logic here
            }
        }

        public void DeleteEmployee(int empNo)
        {
            var employee = GetEmployeeById(empNo);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
