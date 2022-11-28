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
    public class DepartmentsController : Controller
    {
        private readonly Ivanova_AS41_courseContext _context;
        public DepartmentsController(Ivanova_AS41_courseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SearchDepartments (string name, int number)
        {
            DepartmentsModel model = new DepartmentsModel();
            model.Departments = new List<Departments>();
            if (!String.IsNullOrEmpty(name) && number>0)
            {
                var result = await _context.Departments.Where(s => s.Name == name && s.EmployeesNumber == number).DepartmentsEntities().ToListAsync();
                for (int i = 0; i < result.Count; i++)
                {
                    model.Departments.Add(result[i]);
                }
            }
            else if (!String.IsNullOrEmpty(name))
            {
                var result = await _context.Departments.Where(s => s.Name == name ).DepartmentsEntities().ToListAsync();
                for (int i = 0; i < result.Count; i++)
                {
                    model.Departments.Add(result[i]);
                }
            }
            else if (number > 0)
            {
                var result = await _context.Departments.Where(s => s.EmployeesNumber == number).DepartmentsEntities().ToListAsync();
                for (int i = 0; i < result.Count; i++)
                {
                    model.Departments.Add(result[i]);
                }
            }
            else
            {
                var result = await _context.Departments.DepartmentsEntities().ToListAsync();
                for (int i = 0; i < result.Count; i++)
                {
                    model.Departments.Add(result[i]);
                }
            }
            
            return PartialView("_partialDepartmentsTable", model);
        }
        public async Task<int> AddDepartment(Department addInfo)
        {
            try
            {
                if (!String.IsNullOrEmpty(addInfo.Name))
                {
                    Department department = new Department()
                    {
                        Name = addInfo.Name,
                        EmployeesNumber = addInfo.EmployeesNumber
                    };
                    var response = _context.Departments.Add(department);
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
        public async Task<int> EditDepartment(Department addInfo)
        {
            try
            {
                if (!String.IsNullOrEmpty(addInfo.Name))
                {
                    Department department = new Department()
                    {
                        Id=addInfo.Id,
                        Name = addInfo.Name,
                        EmployeesNumber = addInfo.EmployeesNumber
                    };
                    var response = _context.Departments.Update(department);
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
        public async Task<int> DeleteDepartment(int id)
        {
            try
            {
                if (id!=0)
                {
                    var entity = await _context.Departments.SingleOrDefaultAsync(s => s.Id == id); ;
                    var response = _context.Departments.Remove(entity);
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
