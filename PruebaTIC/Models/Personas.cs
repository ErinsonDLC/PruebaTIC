using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PruebaTIC.Models
{
    public class Personas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
    }
}
