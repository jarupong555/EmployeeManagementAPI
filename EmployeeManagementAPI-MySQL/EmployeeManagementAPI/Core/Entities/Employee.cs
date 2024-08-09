using System;
using System.ComponentModel.DataAnnotations; 

namespace EmployeeManagementAPI.Core.Entities
{
    public class Employee
    {
        [Key]  
        public int EmpNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public decimal? Commission { get; set; }
        public int DeptNo { get; set; }
    }
}
