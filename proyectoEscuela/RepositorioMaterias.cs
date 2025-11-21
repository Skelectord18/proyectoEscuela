using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioMaterias
    {
        private Dictionary<string, List<string>> materiasPorCarrera = new Dictionary<string, List<string>>()
        {
            { "Ingenieria en Sistemas", new List<string> { "Calculo ", "Proramacion", "Base de Datos", "Algebra", "Fisica" } },
            { "Ingenieria en Computacion", new List<string> { "Programacion", "Algebra", "Arquitectura de Computadoras", "Calculo" } },
            { "Ingenieria Civil", new List<string> { "Fisica", "Calculo", "Algebra", "Topografia", "Estructuras" } },
            { "Ingenieria Aeronautica", new List<string> { "Fisica", "Calculo", "Aerodinamica", "Algebra", "Materiales Industriales" } },
            { "Medicina", new List<string> { "Biologia", "Quimica", "Anatomia", "Fisica", "Calculo" } }
        };
        public List<string> ObtenerMateriasPorCarrera(string carrera)
        {
            if (materiasPorCarrera.ContainsKey(carrera))
                return materiasPorCarrera[carrera];

            return new List<string>();
        }
    }
}