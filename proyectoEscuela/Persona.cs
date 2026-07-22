using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre : {Nombre}");
            Console.WriteLine($"Apellido : {Apellido}");
            Console.WriteLine($"Edad : {Edad}");
        }
    }
}