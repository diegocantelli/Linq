using System.Collections.Generic;

namespace LinqDemo
{
    public class Department
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static List<Department> GetAllDepartments()
        {
            return new List<Department>
            {
                new Department {Id = 1, Nome = "TI" },
                new Department {Id = 2, Nome = "HR" },
                new Department {Id = 3, Nome = "PayRoll" }
            };
        }
    }
}
