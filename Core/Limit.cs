using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Limit
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }

        public virtual Department Department { get; set; }
    }
}
