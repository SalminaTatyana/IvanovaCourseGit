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
        public List<Limits> model = new List<Limits>();

        public LimitsController(Ivanova_AS41_courseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", model);
        }

        /// <summary>
        /// Метод поиска лимитов
        /// </summary>
        /// <param name="departmentName">Идентификатор ведомства</param>
        /// <param name="valueStart">Начальное значение лимитов</param>
        /// <param name="valueEnd">Конечное значение лимитов</param>
        /// <param name="dateStart">Дата начала поиска</param>
        /// <param name="dateEnd">Дата окончания поиска</param>
        /// <returns>Представление с списком</returns>
        public async Task<IActionResult> SearchLimits(int departmentName, int valueStart, int valueEnd, DateTime? dateStart, DateTime? dateEnd)
        {

            var result = await _context.LimitsViews.Where(s => s.DepartmentId == (departmentName>0 ? departmentName : s.DepartmentId) && s.Value >= valueStart&& s.Value <=( valueEnd>valueStart?valueEnd:s.Value) && s.Date >= (dateStart != null ? dateStart : s.Date)&& s.Date <= (dateEnd != null ? dateEnd : s.Date)).LimitsViewEntities().ToListAsync();
            model = result;
            return PartialView("_partialLimitsTable", model);
        }
        /// <summary>
        /// Метод отображения окна добавления лимитов
        /// </summary>
        /// <returns>Представление со списком</returns>
        public IActionResult AddLimitsInfo()
        {
            return PartialView("_partialAddLimitsModal", model);
        }
        /// <summary>
        /// Метод добавления лимита в базу
        /// </summary>
        /// <param name="departmentId">Идентификатор отдела</param>
        /// <param name="value">Значение лимита</param>
        /// <param name="date">Дата действия лимита</param>
        /// <returns>Объект типа BaseResponse </returns>
        public async Task<ActionResult<BaseResponse>> AddLimits(int departmentId, int value, DateTime date)
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
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Идентификатор отдела и значение лимита не должны быть пустыми." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при добавлении лимита.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
        /// <summary>
        /// Метод редактирования лимита
        /// </summary>
        /// <param name="departmentId">Идентификатор отдела</param>
        /// <param name="value">Значение лимита</param>
        /// <param name="date">Дата действия лимита</param>
        /// <param name="id">Идентификатор лимита</param>
        /// <returns>Объект типа BaseResponse </returns>
        public async Task<ActionResult<BaseResponse>> EditLimits(int departmentId, int value, DateTime date,int id)
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
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Индентификатор отдела, идентификатор лимита и его значение не должны быть пустыми." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при редактировании лимита.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
        /// <summary>
        /// Метод удаления лимита
        /// </summary>
        /// <param name="id">Идентификатор лимита</param>
        /// <returns>Объект типа BaseResponse</returns>
        public async Task<ActionResult<BaseResponse>> DeleteLimits(int id)
        {
            try
            {
                if (id != 0)
                {
                    var entity = await _context.Limits.SingleOrDefaultAsync(s => s.Id == id);
                    var response = _context.Limits.Remove(entity);
                    await _context.SaveChangesAsync();
                    return Ok(new BaseResponse { result = 0, message = default });
                }
                else
                    return Ok(new BaseResponse { result = -1, message = "Индентификатор отдела не должен быть пустым." });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse { result = -2, message = $"Ошибка при удалении лимита.{(ex.InnerException == null ? ex.Message : ex.InnerException.Message)}" });
            }
        }
    }
}
