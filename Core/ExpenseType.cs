using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class ExpenseType
    {
        public ExpenseType()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
