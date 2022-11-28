using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Expense
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int EmployeeId { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ExpenseType Type { get; set; }
    }
}
