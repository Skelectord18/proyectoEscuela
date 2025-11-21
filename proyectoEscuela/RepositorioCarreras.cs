using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MaxAños { get; set; }
    }
    public class RepositorioCarreras
    {
        public List<Carrera> ObtenerCarreras()
        {
            return new List<Carrera>()
            {
                new Carrera { Id = 1, Nombre = "Ingenieria en Sistemas", MaxAños = 5 },
                new Carrera { Id = 2, Nombre = "Ingenieria en Computacion", MaxAños = 5 },
                new Carrera { Id = 3, Nombre = "Ingenieria Civil", MaxAños = 5 },
                new Carrera { Id = 4, Nombre = "Ingenieria Aeronautica", MaxAños = 5 },
                new Carrera { Id = 5, Nombre = "Medicina", MaxAños = 7 }
            };
        }
    }
}
            