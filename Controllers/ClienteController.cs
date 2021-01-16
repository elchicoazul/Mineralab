using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mineralab.Data;
using Mineralab.Models;

namespace Mineralab.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ApplicationDbContext _context;

        public ClienteController(ILogger<ClienteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Cliente.ToList();
            return View(lista);
        }
        public IActionResult Crear()
        {
            return View();
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,nombre,ruc,telefono,email,direccion")] Cliente cliente)
        {   
            if (id != cliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Registrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Crear", cliente);
        }
        
        public IActionResult Eliminar(int? id)
        {
            var contacto = _context.Cliente.Find(id);
            _context.Cliente.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Buscar(string client)
        {
            
            var cliente = from m in _context.Cliente select m;

            if(!String.IsNullOrEmpty(client))
            {
                cliente = _context.Cliente.Where(x=>x.nombre.Contains(client));
            }
            return View("Index", cliente.ToList());
        }
    }
}
