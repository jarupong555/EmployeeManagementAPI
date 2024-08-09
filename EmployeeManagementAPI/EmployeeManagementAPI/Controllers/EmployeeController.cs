using EmployeeManagementAPI.Core.Entities;
using EmployeeManagementAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{empNo}")]
        public ActionResult<Employee> GetEmployee(int empNo)
        {
            var employee = _employeeRepository.GetEmployeeById(empNo);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { empNo = employee.EmpNo }, employee);
        }

        [HttpDelete("{empNo}")]
        public IActionResult DeleteEmployee(int empNo)
        {
            var employee = _employeeRepository.GetEmployeeById(empNo);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.DeleteEmployee(empNo);
            return NoContent();
        }
    }
}
