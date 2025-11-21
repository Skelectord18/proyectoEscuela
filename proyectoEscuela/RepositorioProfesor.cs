using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioProfesor
    {
        private List<Profesor> profesores = new List<Profesor>();
        private RepositorioCarreras repoCarreras = new RepositorioCarreras();
        private RepositorioMaterias repoMaterias = new RepositorioMaterias();
        private RepositorioExperienciaProfesor repoExperiencia = new RepositorioExperienciaProfesor();

        public void RegistrarProfesor()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE PROFESOR ===");

            Profesor profesor = new Profesor();
            Console.Write("Nombre: ");
            profesor.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            profesor.Apellido = Console.ReadLine();
            Console.Write("Edad: ");
            profesor.Edad = ValidarNumero("Edad");
            Console.WriteLine("Documento: ");
            profesor.Documento = Console.ReadLine();

            var carreras = repoCarreras.ObtenerCarreras();

            Console.WriteLine("\n=== CARRERAS DISPONIBLES ===");
            foreach (var c in carreras)
                Console.WriteLine($"{c.Id}. {c.Nombre}");
            Console.WriteLine("Seleccione carrera: ");
            int id = ValidarNumero("Carrera");

            var carreraSeleccionada = carreras.Find(c => c.Id == id);
            if (carreraSeleccionada == null)
            {
                Console.WriteLine("Carrera invalida.");
                return;
            }
            profesor.Carrera = carreraSeleccionada.Nombre;

            var materias = repoMaterias.ObtenerMateriasPorCarrera(carreraSeleccionada.Nombre);

            Console.WriteLine("\n === MATERIAS DISPONIBLES ===");
            for (int i = 0; 1 < materias.Count; i++)
                Console.WriteLine($"{i + 1}. {materias[i]}");
            Console.WriteLine("Seleccione materia: ");
            int idMateria = ValidarNumero("Materia");
            if (idMateria < 1 || idMateria > materias.Count)
            {
                Console.WriteLine("Materia invalida.");
                return;
            }

            profesor.Materia = materias[idMateria - 1];
            int exp = repoExperiencia.CalcularExperiencia(profesor);

            if (exp < 0)
                return;

            profesor.AñosExperiencia = exp;
            profesores.Add(profesor);
            Console.WriteLine("Profesor registrado.");
            Console.ReadKey();
        }
        public void ListarProfesores()
        {
            Console.Clear();

            if (profesores.Count == 0)
            {
                Console.WriteLine("No hay profesores registrados.");
            }
            else
            {
                foreach (var p in profesores)
                    p.MostrarInformacion();
            }
            Console.ReadKey();
        }

        public List<Profesor> ObtenerLista()
        {
            return profesores;
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

        









           