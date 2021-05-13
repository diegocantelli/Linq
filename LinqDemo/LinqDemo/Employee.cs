using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemo
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AnnualSalary { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee{EmployeeId = 101, FirstName = "Tom", LastName ="Daely", Gender = "Male", AnnualSalary = 6000 },
                new Employee{EmployeeId = 102, FirstName = "Mike", LastName ="Mike", Gender = "Male", AnnualSalary = 8000 },
                new Employee{EmployeeId = 103 , FirstName = "Laura", LastName ="laura", Gender = "Female", AnnualSalary = 8000 }
            };
        }
    }
}
