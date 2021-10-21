using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTIC.Models;

namespace PruebaTIC.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext (DbContextOptions<UsuariosContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaTIC.Models.Usuarios> Usuarios { get; set; }
    }
}
