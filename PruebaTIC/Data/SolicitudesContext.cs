using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTIC.Models;

namespace PruebaTIC.Data
{
    public class SolicitudesContext : DbContext
    {
        public SolicitudesContext (DbContextOptions<SolicitudesContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaTIC.Models.Solicitudes> Solicitudes { get; set; }
    }
}
