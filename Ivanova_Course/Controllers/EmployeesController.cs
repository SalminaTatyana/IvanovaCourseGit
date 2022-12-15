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
    public class EmployeesController : Controller
    {
        private readonly Ivanova_AS41_courseContext _context;


        public List<Employees> model = new List<Employees>();
        public EmployeesController(Ivanova_AS41_courseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", model);
        }
        public async Task<IActionResult> SearchEmployees(int departmentName, string firstName, string lastName, string patronymic,int departmentEmployeesCount)
        {

            var result = await _context.EmployeesViews.Where(
                s => s.DepartmentId == (departmentName>0 ? departmentName : s.DepartmentId) &&
                s.FirstName == (!String.IsNullOrEmpty(firstName) ? firstName : s.FirstName)&&
                s.LastName == (!String.IsNullOrEmpty(lastName) ? lastName : s.LastName)&&
                s.Patronymic == (!String.IsNullOrEmpty(patronymic) ? patronymic : s.Patronymic)&&
                s.DepartmentEmployeesCount == (departmentEmployeesCount>0 ? departmentEmployeesCount : s.DepartmentEmployeesCount)).EmployeesViewEntities().ToListAsync();
            model = result;
            return PartialView("_partialEmployeesTable", model);
        }
        public IActionResult AddEmployeesInfo()
        {
            return PartialView("_partialAddEmployeesModal", model);
        }
        public async Task<int> EditEmployeesInfoAsync(int id)
        {
            if (id > 0)
            {
                var result = await _context.Employees.FirstOrDefaultAsync(s => s.Id == id);

                return result.DepartmentId;
            }
            return -1;
        }
        public async Task<int> AddEmployees(int departmentId, string firstName, string lastName, string patronymic)
        {
            try
            {
                if (departmentId>0 && !String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(patronymic))
                {
                    Employee employee = new Employee()
                    {
                        DepartmentId = departmentId,
                        FirstName = firstName,
                        Patronymic = patronymic,
                        LastName = lastName

                    };
                    var response = _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return employee.Id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public async Task<int> EditEmployees(int departmentId, string firstName, string lastName, string patronymic, int id)
        {
            try
            {
                if (departmentId > 0 && !String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(patronymic)&&id>0)
                {
                    Employee employee = new Employee()
                    {
                        Id=id,
                        DepartmentId = departmentId,
                        FirstName = firstName,
                        Patronymic = patronymic,
                        LastName = lastName

                    };
                    var response = _context.Employees.Update(employee);
                    await _context.SaveChangesAsync();
                    return employee.Id;
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        public async Task<int> DeleteEmployees(int id)
        {
            try
            {
                if (id != 0)
                {
                    var entity = await _context.Employees.SingleOrDefaultAsync(s => s.Id == id);
                    var response = _context.Employees.Remove(entity);
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
