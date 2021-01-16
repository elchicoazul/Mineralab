using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mineralab.Models;
using System.Dynamic;

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
              var ListMetodos=_context.Metodo.ToList();
            var LisPruebas=_context.Prueba.ToList();
            //Resultado resultado = new Resultado();
            dynamic model = new ExpandoObject();
            //model.r = resultado;
            model.meto = ListMetodos;
            model.prue=LisPruebas;
          
            return View(model);
        }
        [HttpPost]
        public IActionResult Registrar([Bind(Prefix="met")]Metodo objContacto){
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
