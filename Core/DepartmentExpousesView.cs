using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class DepartmentExpousesView
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? Sum { get; set; }
        public int Value { get; set; }
        public int? EndMouthSum { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
