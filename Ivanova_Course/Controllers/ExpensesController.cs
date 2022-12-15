using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly Ivanova_AS41_courseContext _context;

        public ExpensesViewModel allExpenses;
        public Limits model = new Limits();

        public ExpensesController(Ivanova_AS41_courseContext context)
        {
            _context = context;
            //allExpenses.ExpensesTypeModel = _context.ExpenseTypes.DepartmentsEntities().ToListAsync();
            //model.Departments = new List<Department>();
            //for (int i = 0; i < departmentName.Result.Count; i++)
            //{
            //    model.Departments.Add(new Department());

            //    model.Departments[i].Id = departmentName.Result[i].Id;

            //    model.Departments[i].Name = departmentName.Result[i].Name;

            //}
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
