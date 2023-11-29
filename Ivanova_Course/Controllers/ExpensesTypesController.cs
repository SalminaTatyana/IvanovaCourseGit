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
        /// <summary>
        /// Метод поиска типа трат
        /// </summary>
        /// <param name="name">Наименование типа трат</param>
        /// <param name="description">Описание типа трат</param>
        /// <returns>Представление со списком</returns>
        public async Task<IActionResult> SearchExpensesType(string name,  string description)
        {
            List<ExpensesTypes> model = new List<ExpensesTypes>();
            var result = await _context.ExpenseTypes.Where(s=>s.Name == (!String.IsNullOrEmpty(name) ? name : s.Name) && s.Description == (!String.IsNullOrEmpty(description) ? description : s.Description)).ExpensesTypesEntities().ToListAsync();
            for (int i = 0; i < result.Count; i++)
            {
                model.Add(result[i]);
            }
            return PartialView("~/Views/ExpensesType/_partialExpensesTypeTable.cshtml", model);
        }
        /// <summary>
        /// Мектод добавления типа трат
        /// </summary>
        /// <param name="addInfo">Тип трат</param>
        /// <returns>Объект типа BaseResponse</returns>
        public async Task<ActionResult<BaseResponse>> AddExpensesType(ExpensesTypes addInfo)
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
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Наименование типа трат не долно быть пустым." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при добавлении типа трат.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
        /// <summary>
        /// Мектод редактирования типа трат
        /// </summary>
        /// <param name="addInfo">Тип трат</param>
        /// <returns>Объект типа BaseResponse</returns>
        public async Task<ActionResult<BaseResponse>> EditExpensesType(ExpensesTypes addInfo)
        {
            try
            {
                if (!String.IsNullOrEmpty(addInfo.Name)&&addInfo.Id>0)
                {
                    ExpenseType department = new ExpenseType()
                    {
                        Id = addInfo.Id,
                        Name = addInfo.Name,
                        Description = addInfo.Description
                    };
                    var response = _context.ExpenseTypes.Update(department);
                    await _context.SaveChangesAsync();
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Наименование типа трат и его идентификатор не должны быть пустым." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при редактировании типа трат.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
        /// <summary>
        /// Мектод удаления типа трат
        /// </summary>
        /// <param name="id">Идентификатор типа трат</param>
        /// <returns>Объект типа BaseResponse</returns>
        public async Task<ActionResult<BaseResponse>> DeleteExpensesType(int id)
        {
            try
            {
                if (id != 0)
                {
                    var entity = await _context.ExpenseTypes.SingleOrDefaultAsync(s => s.Id == id); ;
                    var response = _context.ExpenseTypes.Remove(entity);
                    await _context.SaveChangesAsync();
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Индентификатор типа трат не должен быть пустым." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при удалении типа трат.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
    }
}
