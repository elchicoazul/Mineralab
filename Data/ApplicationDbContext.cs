using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mineralab.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         public DbSet<Mineralab.Models.Metodo> Metodo { get; set; }
         public DbSet<Mineralab.Models.Cliente> Cliente { get; set; }
         public DbSet<Mineralab.Models.Prueba> Prueba { get; set; }
         public DbSet<Mineralab.Models.Columna> Columna { get; set; }
    }
}
