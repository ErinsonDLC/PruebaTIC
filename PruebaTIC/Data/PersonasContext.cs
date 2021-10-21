using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTIC.Models;

namespace PruebaTIC.Data
{
    public class PersonasContext : DbContext
    {
        public PersonasContext (DbContextOptions<PersonasContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaTIC.Models.Personas> Personas { get; set; }
    }
}
