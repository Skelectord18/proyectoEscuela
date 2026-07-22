using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace UniversidadPOO
{
    public class Alumno : Persona
    {
        public int CarreraId { get; set; }
        public int GrupoId { get; set; }
        public string NombreCarrera { get; set; }
        public int AñoCursado { get; set; }
        public override void MostrarInformacion()
        {
            Console.WriteLine($"ALUMNO - ID: {Id}");
            base.MostrarInformacion();
            Console.WriteLine($"ID Carrera: {CarreraId}");
        }
    }
}
      