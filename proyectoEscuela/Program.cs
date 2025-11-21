using System;

namespace UniversidadPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            RepositorioAlumno repoAlumno = new RepositorioAlumno();
            RepositorioProfesor repoProfesor = new RepositorioProfesor();
            RepositorioDocumentosAlumno repoDocAlumno = new RepositorioDocumentosAlumno();
            RepositorioDocumentosProfesor repoDocProfesor = new RepositorioDocumentosProfesor();
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("========== SISTEMA UNIVERSITARIO ==========");
                Console.WriteLine("1.Registrar Alumno");
                Console.WriteLine("2.Listar Alumnos");
                Console.WriteLine("3.Registrar Documentos Alumno");
                Console.WriteLine("4.Verificar Documentos Alumno");

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("5.Registrar Profesor");
                Console.WriteLine("6.Listar Profesores");
                Console.WriteLine("7.Registrar Documentos Profesor");
                Console.WriteLine("8.Verificar Documentos Profesor");

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("ESC.Salir");
                Console.WriteLine("=================================");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        repoAlumno.AgregarAlumno();
                        break;
                    case ConsoleKey.D2:
                        repoAlumno.ListarAlumnos();
                        break;
                    case ConsoleKey.D3:
                        {
                            Alumno alumno = SeleccionarAlumno(repoAlumno);
                            if (alumno != null)
                                repoDocAlumno.RegistrarDocumentosAlumno(alumno);
                        }
                        break;
                    case ConsoleKey.D4:
                        {
                            Alumno alumno = SeleccionarAlumno(repoAlumno);
                            if (alumno != null)
                                repoDocAlumno.VerificarDocumentos(alumno);
                        }
                        break;

                    case ConsoleKey.D5:
                        repoProfesor.RegistrarProfesor();
                        break;
                    case ConsoleKey.D6:
                        repoProfesor.ListarProfesores();
                        break;
                    case ConsoleKey.D7:
                        {
                            Profesor profesor = SeleccionarProfesor(repoProfesor);
                            if (profesor != null)
                                repoDocProfesor.RegistrarDocumentosProfesor(profesor);
                        }
                        break;
                    case ConsoleKey.D8:
                        {
                            Profesor profesor = SeleccionarProfesor(repoProfesor);
                            if (profesor != null)
                                repoDocProfesor.VerificarDocumentos(profesor);
                        }
                        break;

                    case ConsoleKey.Escape:
                        salir = ConfirmarSalida();
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static Alumno SeleccionarAlumno(RepositorioAlumno repo)
        {
            var lista = repo.ObtenerLista();

            Console.Clear();
            if (lista.Count == 0)
            {
                Console.WriteLine("=== No hay alumno registrados.");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine("=== SELECCIONE UN ALUMNO ===\n");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lista[i].Nombre} {lista[i].Apellido} - {lista[i].Documento}");
            }

            Console.Write("\nSeleccione una opcion: ");
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                if (opcion >= 1 && opcion <= lista.Count)
                    return lista[opcion - 1];
            }
            Console.WriteLine("Seleccion invalida.");
            Console.ReadKey();
            return null;
        }

        static Profesor SeleccionarProfesor(RepositorioProfesor repo)
        {
            var lista = repo.ObtenerLista();
            Console.Clear();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay profesores registrados.");
                Console.ReadKey();
                return null;
            }
            Console.WriteLine("=== SELECCIONE UN PROFESOR ===\n");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lista[i].Nombre} {lista[i].Apellido} - {lista[i].Documento}");
            }
            Console.Write("\nSeleccione una opcion: ");
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                if (opcion >= 1 && opcion <= lista.Count)
                    return lista[opcion - 1];
            }
            Console.WriteLine("Seleccion invalida.");
            Console.ReadKey();
            return null;
        }

        static bool ConfirmarSalida()
        {
            Console.Clear();
            Console.Write("¿Desea salir? (S/N): ");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.S)
            {
                Console.WriteLine("Saliendo del sistema...");
                System.Threading.Thread.Sleep(800);
                return true;
            }
            return false;
        }
    }
}




















