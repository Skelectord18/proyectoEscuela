using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace UniversidadPOO
{
    public class RepositorioAlumno
    {
        private List<Alumno> alumnos = new List<Alumno>();
        private RepositorioCarreras repoCarrera = new RepositorioCarreras();
        public void AgregarAlumno()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE ALUMNO ===");

            Alumno alumno = new Alumno();
            Console.WriteLine("Nombre: ");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            alumno.Apellido = Console.ReadLine();
            Console.WriteLine("Edad: ");
            alumno.Edad = ValidarNumero("Edad");
            Console.WriteLine("Documento ");
            alumno.Documento = Console.ReadLine();

            var carreras = repoCarrera.ObtenerCarreras();
            Console.WriteLine("\n=== CARRERAS DISPONIBLES ===");
            foreach (var c in carreras)

                Console.WriteLine($"{c.Id}. {c.Nombre} (Max años: {c.MaxAños})");
            Console.WriteLine("\nSeleccione carrera: ");
            int idCarrera = ValidarNumero("Carrera");

            var carreraSeleccionada = carreras.Find(c => c.Id == idCarrera);
            if (carreraSeleccionada == null)
            {
                Console.WriteLine("Carrera invalida.");
                return;
            }
            alumno.Carrera = carreraSeleccionada.Nombre;

            Console.WriteLine($"Año cursado (1-{carreraSeleccionada.MaxAños}): ");
            int año = ValidarNumero("Año cursado");
            if (año < 1 || año > carreraSeleccionada.MaxAños)
            {
                Console.WriteLine("Año invalido.");
                return;
            }

            alumno.AñoCursado = año;
            alumnos.Add(alumno);
            Console.WriteLine("Alumno registrado.");
            Console.ReadKey();
        }
        public void ListarAlumnos()
        {
            Console.Clear();
            if (alumnos.Count == 0)
            {
                Console.WriteLine("No hay alumno registrados.");
            }
            else
            {
                foreach (var a in alumnos)
                    a.MostrarInformacion();
            }
            Console.ReadKey();
        }
        public List<Alumno> ObtenerLista()
        {
            return alumnos;
        }
        private int ValidarNumero(string campo)
        {
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
                Console.WriteLine($"Valor invalido ({campo}). Intente de nuevo: ");
                    return numero;
        }
    }
}
            


           