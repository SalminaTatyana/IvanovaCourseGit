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
    public class ExpensesTypesController : Controller
    {
        private readonly Ivanova_AS41_courseContext _context;
        public ExpensesTypesController(Ivanova_AS41_courseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SearchExpensesType(string name,  string description)
        {
            ExpensesTypeModel model = new ExpensesTypeModel();
            model.ExpensensTypes = new List<ExpensesTypes>();
            var result = await _context.ExpenseTypes.Where(s=>s.Name == (!String.IsNullOrEmpty(name) ? name : s.Name) && s.Description == (!String.IsNullOrEmpty(description) ? description : s.Description)).ExpensesTypesEntities().ToListAsync();
            for (int i = 0; i < result.Count; i++)
            {
                model.ExpensensTypes.Add(result[i]);
            }
            return PartialView("~/Views/ExpensesType/_partialExpensesTypeTable.cshtml", model);
        }
        public async Task<int> AddExpensesType(ExpensesTypes addInfo)
        {
            try
            {
                if (!String.IsNullOrEmpty(addInfo.Name))
                {
                    ExpenseType department = new ExpenseType()
                    {
                        Name = addInfo.Name,
                        Description = addInfo.Description
                    };
                    var response = _context.ExpenseTypes.Add(department);
                    await _context.SaveChangesAsync();
                    return department.Id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public async Task<int> EditExpensesType(ExpensesTypes addInfo)
        {
            try
            {
                if (!String.IsNullOrEmpty(addInfo.Name))
                {
                    ExpenseType department = new ExpenseType()
                    {
                        Id = addInfo.Id,
                        Name = addInfo.Name,
                        Description = addInfo.Description
                    };
                    var response = _context.ExpenseTypes.Update(department);
                    await _context.SaveChangesAsync();
                    return department.Id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public async Task<int> DeleteExpensesType(int id)
        {
            try
            {
                if (id != 0)
                {
                    var entity = await _context.ExpenseTypes.SingleOrDefaultAsync(s => s.Id == id); ;
                    var response = _context.ExpenseTypes.Remove(entity);
                    await _context.SaveChangesAsync();
                    return id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
    }
}
