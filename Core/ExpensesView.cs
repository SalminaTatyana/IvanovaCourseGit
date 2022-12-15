using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class ExpensesView
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesNumber { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
