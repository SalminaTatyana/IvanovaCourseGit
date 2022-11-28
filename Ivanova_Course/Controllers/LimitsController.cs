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
        public LimitsController(Ivanova_AS41_courseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            LimitsModel model = new LimitsModel();
            model.Limits = new List<Limits>();
            var result = await _context.Departments.DepartmentsEntities().ToListAsync();
            for (int i = 0; i < result.Count; i++)
            {
                model.Limits.Add(new Limits());
                model.Limits[i].DepartmentId = result[i].Id;
                model.Limits[i].DepartmentName = result[i].Name;
            }
            return View("Index",model);
        }
        public async Task<IActionResult> SearchLimits(int departmentId, int value, DateTime? date)
        {
            LimitsModel model = new LimitsModel();
            model.Limits = new List<Limits>();
           
                var result = await _context.Limits.Where(s => s.DepartmentId == (departmentId>0?departmentId:s.DepartmentId) && s.Value == (value > 0 ? value : s.Value)&& s.Date == (date != null ? date : s.Date)).LimitsEntities().ToListAsync();
                for (int i = 0; i < result.Count; i++)
                {
                model.Limits.Add(new Limits());
                model.Limits[i].Id = result[i].Id; 
                model.Limits[i].DepartmentId = result[i].DepartmentId;
                model.Limits[i].Value = result[i].Value;
                var departmentName= _context.Departments.SingleOrDefaultAsync(s => s.Id == result[i].DepartmentId);
                model.Limits[i].DepartmentName = departmentName.Result.Name;
                model.Limits[i].Date = result[i].Date;
                }

            return PartialView("_partialLimitsTable", model);
        }
        public async Task<IActionResult> AddLimitsInfo()
        {
            LimitsModel model = new LimitsModel();
            model.Limits = new List<Limits>();

            var departmentName = await _context.Departments.DepartmentsEntities().ToListAsync();
            for (int i = 0; i < departmentName.Count; i++)
            {
                model.Limits.Add(new Limits());

                model.Limits[i].DepartmentId = departmentName[i].Id;

                model.Limits[i].DepartmentName = departmentName[i].Name;

            }

            return PartialView("_partialAddLimitsModal", model);
        }
        public async Task<int> AddLimits(int departmentId, int value, DateTime date)
        {
            try
            {
                if (departmentId > 0&& value > 0)
                {
                    Limit limit = new Limit()
                    {
                        DepartmentId=departmentId,
                        Date=date,
                        Value=value

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
        public async Task<int> EditLimits(Limits editInfo)
        {
            try
            {
                if (editInfo.Value > 0 && editInfo.DepartmentId > 0)
                {
                    Limit limit = new Limit()
                    {
                        Id=editInfo.Id,
                        DepartmentId = editInfo.DepartmentId,
                        Date = editInfo.Date,
                        Value = editInfo.Value

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
