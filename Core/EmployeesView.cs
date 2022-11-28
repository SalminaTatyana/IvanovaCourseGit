using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class EmployeesView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesCount { get; set; }
    }
}
