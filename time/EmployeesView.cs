using System;
using System.Collections.Generic;

#nullable disable

namespace time
{
    public partial class EmployeesView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesCount { get; set; }
    }
}
