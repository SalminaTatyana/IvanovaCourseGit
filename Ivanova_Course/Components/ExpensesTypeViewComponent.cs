using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Components
{
    public class ExpensesTypeViewComponent : ViewComponent
    {
        private readonly Ivanova_AS41_courseContext _context;
        public ExpensesTypeViewComponent(Ivanova_AS41_courseContext context)
        {
            _context = context;
        }
            public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _context.ExpenseTypes.ExpensesTypesEntities().ToListAsync();
            return View(result);
        }
    }
}
