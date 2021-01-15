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
    public class PruebaController : Controller
    {
        private readonly ILogger<PruebaController> _logger;
        private readonly ApplicationDbContext _context;

        public PruebaController(ILogger<PruebaController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context=context;
        }


        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Registrar([Bind(Prefix="pru")]Prueba objContacto){
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
