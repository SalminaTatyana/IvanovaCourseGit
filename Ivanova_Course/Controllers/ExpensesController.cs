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
    }
}
