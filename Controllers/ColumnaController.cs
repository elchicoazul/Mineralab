using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mineralab.Models;
using Mineralab.Data;

namespace Mineralab.Controllers
{
    public class ColumnaController : Controller
    {
        private readonly ILogger<ColumnaController> _logger;
 private readonly ApplicationDbContext _context;
        public ColumnaController(ILogger<ColumnaController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Registrar([Bind(Prefix="colunm")]Columna objContacto){
            if (ModelState.IsValid)
            {
                _context.Add(objContacto);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View("index", objContacto);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
