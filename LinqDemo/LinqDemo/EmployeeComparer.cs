using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemo
{
    // classe utilizada para determinar quando um tipo complexo será considerado igual a um outro
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.EmployeeId == y.EmployeeId;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.EmployeeId.GetHashCode() ^ obj.FirstName.GetHashCode();
        }
    }
}
