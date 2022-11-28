using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Limits = new HashSet<Limit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeesNumber { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Limit> Limits { get; set; }
    }
}
