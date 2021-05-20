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
        public List<string> Habilidades { get; set; }
        public int DepartmentId { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>
            {
                new Employee{
                    EmployeeId = 101,
                    FirstName = "Tom",
                    LastName ="Daely",
                    Gender = "Male",
                    AnnualSalary = 6000,
                    DepartmentId = 1,
                    Habilidades = new List<string>
                    {
                        "C#",
                        "Sql Server"
                    }
                },
                new Employee{
                    EmployeeId = 102,
                    FirstName = "Mike",
                    LastName ="Mike",
                    Gender = "Male",
                    AnnualSalary = 8000,
                    DepartmentId = 2,
                    Habilidades = new List<string>
                    {
                        "Angular",
                        "Javascript"
                    }
                },
                new Employee{
                    EmployeeId = 103 ,
                    FirstName = "Laura",
                    LastName ="laura",
                    Gender = "Female",
                    AnnualSalary = 8000,
                    DepartmentId = 3,
                    Habilidades = new List<string>
                    {
                        "Python",
                        "Data Science"
                    }
                },
                new Employee{
                    EmployeeId = 104 ,
                    FirstName = "Julia",
                    LastName ="julia",
                    Gender = "Female",
                    AnnualSalary = 9000,
                    DepartmentId = 1,
                    Habilidades = new List<string>
                    {
                        "React",
                        "SCSS"
                    }
                },
                new Employee{
                    EmployeeId = 105 ,
                    FirstName = "Joao",
                    LastName ="joao",
                    Gender = "Male",
                    AnnualSalary = 6000,
                    DepartmentId = 2,
                    Habilidades = new List<string>
                    {
                        "C#",
                        "RabbitMq"
                    }
                }
            };
        }
    }
}
