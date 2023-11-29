using System;
using System.Collections.Generic;

#nullable disable

namespace time
{
    public partial class Employee
    {
        public Employee()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
