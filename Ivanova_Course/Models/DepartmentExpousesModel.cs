using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class DepartmentExpousesModel
    {
        List<DepartmentExpouses> DepartmentExpouses;
    }
    public class DepartmentExpouses
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
