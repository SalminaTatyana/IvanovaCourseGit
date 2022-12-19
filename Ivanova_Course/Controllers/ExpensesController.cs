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
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SearchDepartmentExpouses(int DepartmentId,  int startSum, int endSum, int startValue, int endValue,  int startMonth, int endMonth, int startYear, int endYear)
        {
            List<DepartmentExpouses> model = new List<DepartmentExpouses>();
            var result = await _context.DepartmentExpousesViews.Where(
                s=> s.DepartmentId ==(DepartmentId > 0 ? DepartmentId : s.DepartmentId)&&
                s.Sum>=startSum&&
                s.Sum<=(endSum>0?endSum:s.Sum)&&
                s.Value>=startValue&&
                s.Value<=(endValue>0? endValue:s.Value)&&
                s.Month>= startMonth&&
                s.Month<=(endMonth>0?endMonth : s.Month)&&
                s.Year >= startYear &&
                s.Year <= (endYear > 0 ? endYear : s.Year)).DepartmentExpousesEntities().ToListAsync();
            for (int i = 0; i < result.Count; i++)
            {
                model.Add(result[i]);
            }
            return PartialView("_partialDepartmentExpousesTable.cshtml", model);
        }
        public async Task<int> AddDepartmentExpouses(ExpensesTypes addInfo)
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
        public async Task<int> EditDepartmentExpouses(ExpensesTypes addInfo)
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
        public async Task<int> DeleteDepartmentExpouses(int id)
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
        public async Task<IActionResult> SearchExpenses(int DepartmentId, int expensesType, int startSum, int endSum, string firstName, string lastName, string patronymic, string description, int endNumber,int startNumber,DateTime startDate,DateTime endDate)
        {
            List<Expenses> model = new List<Expenses>();
            var result = await _context.ExpensesViews.Where(
                s => s.DepartmentId == (DepartmentId > 0 ? DepartmentId : s.DepartmentId) &&
                s.TypeId == (expensesType > 0 ? expensesType : s.TypeId) &&
                s.Sum >= startSum &&
                s.DepartmentEmployeesNumber >= startNumber &&
                s.Sum <= (endSum > 0 ? endSum : s.Sum) &&
                s.DepartmentEmployeesNumber <= (endNumber > 0 ? endNumber : s.DepartmentEmployeesNumber) &&
                s.Date >= startDate &&
                s.Date <= (endDate > startDate ? endDate : s.Date) &&
                s.FirstName ==(!String.IsNullOrEmpty(firstName)?firstName:s.FirstName) &&
                s.LastName ==(!String.IsNullOrEmpty(lastName)?firstName:s.LastName) &&
                s.Patronymic ==(!String.IsNullOrEmpty(patronymic) ?patronymic:s.Patronymic) &&
                s.Description ==(!String.IsNullOrEmpty(description) ?description:s.Description) 
                ).ExpensesViewEntities().ToListAsync();
            for (int i = 0; i < result.Count; i++)
            {
                model.Add(result[i]);
            }
            return PartialView("~/Views/Expenses/_partialExpensesTable.cshtml", model);
        }
    }
}
