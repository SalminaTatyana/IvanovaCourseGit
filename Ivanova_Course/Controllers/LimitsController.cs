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
    public class LimitsController : Controller
    {
        private readonly Ivanova_AS41_courseContext _context;

        public Task<List<Departments>> departmentName;
        public LimitsModel model = new LimitsModel();

        public LimitsController(Ivanova_AS41_courseContext context)
        {
            _context = context;
            departmentName = _context.Departments.DepartmentsEntities().ToListAsync();
            model.Departments = new List<Department>();
            for (int i = 0; i < departmentName.Result.Count; i++)
            {
                model.Departments.Add(new Department());

                model.Departments[i].Id = departmentName.Result[i].Id;

                model.Departments[i].Name = departmentName.Result[i].Name;

            }
        }

        public IActionResult Index()
        {
            return View("Index", model);
        }
        public async Task<IActionResult> SearchLimits(int departmentId, int value, DateTime? date)
        {

            var result = await _context.Limits.Include(s=>s.Department).Where(s => s.DepartmentId == (departmentId > 0 ? departmentId : s.DepartmentId) && s.Value == (value > 0 ? value : s.Value) && s.Date == (date != null ? date : s.Date)).LimitsEntities().ToListAsync();
            model.Limits = result;

            return PartialView("_partialLimitsTable", model);
        }
        public IActionResult AddLimitsInfo()
        {
            return PartialView("_partialAddLimitsModal", model);
        }
        public async Task<int> AddLimits(int departmentId, int value, DateTime date)
        {
            try
            {
                if (departmentId > 0 && value > 0)
                {
                    Limit limit = new Limit()
                    {
                        DepartmentId = departmentId,
                        Date = date,
                        Value = value

                    };
                    var response = _context.Limits.Add(limit);
                    await _context.SaveChangesAsync();
                    return limit.Id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public async Task<int> EditLimits(int departmentId, int value, DateTime date,int id)
        {
            try
            {
                if (value > 0 && departmentId > 0&&id>0)
                {
                    Limit limit = new Limit()
                    {
                        Id = id,
                        DepartmentId = departmentId,
                        Date = date,
                        Value = value

                    };
                    var response = _context.Limits.Update(limit);
                    await _context.SaveChangesAsync();
                    return limit.Id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public async Task<int> DeleteLimits(int id)
        {
            try
            {
                if (id != 0)
                {
                    var entity = await _context.Limits.SingleOrDefaultAsync(s => s.Id == id);
                    var response = _context.Limits.Remove(entity);
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
