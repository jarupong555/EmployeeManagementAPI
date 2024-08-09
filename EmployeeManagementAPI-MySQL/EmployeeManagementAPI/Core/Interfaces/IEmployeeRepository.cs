using System.Collections.Generic;
using EmployeeManagementAPI.Core.Entities;

namespace EmployeeManagementAPI.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int empNo);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int empNo);
    }
}
