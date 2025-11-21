using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace UniversidadPOO
{
    public class Alumno : Persona
    {
        public string Carrera { get; set; }
        public int AñoCursado { get; set; }
        public override void MostrarInformacion()
        {
            Console.WriteLine($"\n--- ALUMNO ---");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Documento: {Documento}");
            Console.WriteLine($"Carrera: {Carrera}");
            Console.WriteLine($"Añocursado: {AñoCursado}");
            Console.WriteLine("--------------------------");
        }
    }
}
      