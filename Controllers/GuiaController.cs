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
    public class GuiaController : Controller
    {
        private readonly ILogger<GuiaController> _logger;
        private readonly ApplicationDbContext _context;

        public GuiaController(ILogger<GuiaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
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

    }
}
