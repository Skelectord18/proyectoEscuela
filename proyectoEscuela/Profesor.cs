using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class Profesor : Persona
    {
        public string Materia { get; set; } = "";
        public string Carrera { get; set; }
        public int AñosExperiencia { get; set; }
        public override void MostrarInformacion()
        {
            Console.WriteLine("\n--- DATOS DEL PROFESOR ---");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Documento: {Documento}");
            Console.WriteLine($"Carrera: {Carrera}");
            Console.WriteLine($"Materia: {Materia}");
            Console.WriteLine($"Años de experiencia: {AñosExperiencia}");
        }
    }
}

    
