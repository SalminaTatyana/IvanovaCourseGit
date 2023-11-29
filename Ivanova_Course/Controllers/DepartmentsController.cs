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
            try
            {
                var result = await _context.Departments.Where(s => s.Name == (!String.IsNullOrEmpty(name)  ? name : s.Name) && s.EmployeesNumber == (number>0? number:s.EmployeesNumber)).DepartmentsEntities().ToListAsync();
            return PartialView("_partialDepartmentsTable", result);
            }
            catch (Exception)
            {
                return PartialView("_partialDepartmentsTable", null);
            }
            
        }
        public async Task<ActionResult<BaseResponse>> AddDepartment(Department addInfo)
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
                    return Ok(new BaseResponse { result = 0, message = default }); 
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Имя отдела не должно быть пустым." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при добавлении отдела.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
        public async Task<ActionResult<BaseResponse>> EditDepartment(Department addInfo)
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
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Имя отдела не должно быть пустым." });
            }
            catch(Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при редактировании отдела.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
        public async Task<ActionResult<BaseResponse>> DeleteDepartment(int id)
        {
            try
            {
                if (id!=0)
                {
                    var entity = await _context.Departments.SingleOrDefaultAsync(s => s.Id == id);
                    if (entity!=null)
                    {
                        var response = _context.Departments.Remove(entity);
                        await _context.SaveChangesAsync();
                    }
                    return Ok(new BaseResponse { result = 0, message = default }); 
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Id=0" });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при удалении отдела. {(ex.InnerException==null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
    }
}
