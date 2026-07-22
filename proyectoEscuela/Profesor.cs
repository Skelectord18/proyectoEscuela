using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class Profesor : Persona
    {
        public int MateriaId { get; set; }
        public int AñosExperiencia { get; set; }
        public List<int> GruposIds { get; set; } = new List<int>();
        public override void MostrarInformacion()
        {
            Console.WriteLine("\n--- DATOS DEL PROFESOR ---");
            base.MostrarInformacion();
            Console.WriteLine($"ID Materia asignada: {MateriaId}");
            Console.WriteLine($"Años de Experiencia: {AñosExperiencia}");
        }
    }
}


