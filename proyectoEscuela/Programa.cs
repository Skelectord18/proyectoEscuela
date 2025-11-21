using ConsoleApp3.Modulos;
using System;
namespace UniversidadPOO
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA UNIVERSITARIO ====");
                Console.WriteLine("1. Registrar Alumno");
                Console.WriteLine("2. Registrar Profesor");
                Console.WriteLine("3. Ver todos los registros");
                Console.WriteLine("ESC. Salir");
                Console.WriteLine("===============================");
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        personas.Add(Alumno.RegistrarAlumno());
                        break;
                    case ConsoleKey.D2:
                        personas.Add(Profesor.RegistrarProfesor());
                        break;
                    case ConsoleKey.D3:
                        Persona.MostrarPersonas(personas);
                        break;
                    case ConsoleKey.Escape:
                        salir = ConfirmarSalida();
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalidada. Presiona cualquier tecla para salir...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static bool ConfirmarSalida()
        {
            Console.Clear();
            Console.WriteLine("¿Deseas salir del programa? (S/N)");
            ConsoleKey respuesta = Console.ReadKey(true).Key;

            if (respuesta == ConsoleKey.S)
            {
                Console.WriteLine("Saliendo del sistema...");
                return true;
            }
            else
            {
                Console.WriteLine("Operacion cancelada. Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                return false;
            }
        }
    }
}

