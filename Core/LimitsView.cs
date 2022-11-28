using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class LimitsView
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesCount { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
