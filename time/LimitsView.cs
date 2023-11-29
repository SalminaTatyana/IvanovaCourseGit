using System;
using System.Collections.Generic;

#nullable disable

namespace time
{
    public partial class LimitsView
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesCount { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
