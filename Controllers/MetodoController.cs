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
    public class MetodoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
           private readonly ApplicationDbContext _context;

        public MetodoController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }

        public IActionResult Index()
        {
            return View();
        }
 [HttpPost]
        public IActionResult Registrar(Metodo objContacto){
            if (ModelState.IsValid)
            {
                _context.Add(objContacto);
                _context.SaveChanges();
                return RedirectToAction("ListarMetodo");
            }
            return View("index", objContacto);
        }
        
 public IActionResult ListarMetodo()
        {
            var resultado=_context.Metodo.ToList();
            return View(resultado);
        }
        
    }
}
