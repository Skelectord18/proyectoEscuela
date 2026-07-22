using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace UniversidadPOO
{
    class Program
    {
        static RepositorioCarreras repoCarreras = new RepositorioCarreras();
        static RepositorioMaterias repoMaterias = new RepositorioMaterias();
        static RepositorioAlumno repoAlumnno = new RepositorioAlumno();
        static RepositorioGrupos repoGrupos = new RepositorioGrupos();
        static RepositorioProfesor repoProfesor = new RepositorioProfesor();
        static RepositorioExperienciaProfesor repoExperiencia = new RepositorioExperienciaProfesor();
        static RepositorioDocumentosAlumno repoDocsAlumno = new RepositorioDocumentosAlumno();
        static RepositorioDocumentosProfesor repoDocsProfe = new RepositorioDocumentosProfesor();


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("SISTEMA DE GESTION UNIVERSITARIA");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Registrar Nuevo ALUMNO");
                Console.WriteLine("2. Registar Nuevo PROFESOR");
                Console.WriteLine("3. Gestionar DOCUMENTOS (Entregar/Ver)");
                Console.WriteLine("4. Ver Lista de Alumnos");
                Console.WriteLine("5. Ver Lista de Profesores");
                Console.WriteLine("6. Salir");
                Console.WriteLine("===================================");
                Console.Write("Selecciona una opcion:");
                string opcion = Console.ReadLine();
                try
                {
                    switch (opcion)
                    {
                        case "1":
                            RegistrarAlumno();
                            break;
                        case "2":
                            RegistrarProfesor();
                            break;
                        case "3":
                            MenuDocumentos();
                            break;
                        case "4":
                            ListarAlumnos();
                            break;
                        case "5":
                            ListarProfesores();
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Opcion no valida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n¡OCURRIO UN ERROR!: " + ex.Message);
                    Console.ResetColor();
                }

                Console.WriteLine("\nPresiona cualquier tecla para volver al menu...");
                Console.ReadKey();
            }
        }

        static void RegistrarAlumno()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE ALUMNO ---");
            Console.WriteLine("Selecciona la carrera:");
            var listaCarreras = repoCarreras.ObtenerCarreras();
            foreach (var c in listaCarreras)
            {
                Console.WriteLine($"ID: {c.Id} | {c.Nombre} ({c.MaxAños}años)");
            }
            int idCarrera = PedirNumero("Escribe el ID de la carrera: ");

                var listaGrupos = repoGrupos.ObtenerPorCarrera(idCarrera);
                if (listaGrupos.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNo hay grupos registrados para esta carrera en la base de datos.");
                    Console.WriteLine("Por favor, asigna al menos un grupo desde SQL Server.");
                    Console.ResetColor();
                }
                Console.WriteLine("\nSelecciona el Grupo:");
                foreach (var g in listaGrupos)
                {
                    Console.WriteLine($"ID: {g.Id} | Grupo: {g.Nombre}");
                }
                int idGrupo = PedirNumero("Escribe el ID del grupo: ");

                Console.Write("\nNombre del Alumno:");
                string nombre = Console.ReadLine();
                Console.Write("Apellido del Alumno:");
                string apellido = Console.ReadLine();
                int edad = PedirNumero("Edad del Alumno: ");

            Alumno nuevoAlumno = new Alumno
            {
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                CarreraId = idCarrera,
                GrupoId = idGrupo
            };

            repoAlumnno.AgregarAlumno(nuevoAlumno);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n¡Alumno registrado con exito!");
            Console.ResetColor();
        }
        static void ListarAlumnos()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE ALUMNOS ---");
            var lista = repoAlumnno.ObtenerAlumnos();
            if (lista.Count == 0)
                Console.WriteLine("No hay alumnos registrados.");
            foreach (var al in lista)
            {
                Console.WriteLine($"ID: {al.Id} | {al.Nombre} {al.Apellido} | Edad: {al.Edad} | CarreraID: {al.CarreraId} | GrupoID: {al.GrupoId}");
            }
        }

        static void RegistrarProfesor()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE PROFESOR ---");
            Console.WriteLine("Selecciona la materia que impartira:");
            var listaMaterias = repoMaterias.ObtenerTodas();
            foreach (var m in listaMaterias)
            {
                Console.WriteLine($"ID: {m.Id} | Materia: {m.Nombre}");
            }
            int idMateria = PedirNumero("Escribe el ID de la materia: ");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            int edad = PedirNumero("Edad actual: ");
            int edadInicio = PedirNumero("¿A que edad Comenzo a trabajar?: ");

            int experienciaCalculada = repoExperiencia.CalcularExperiencia(edad, edadInicio);
            Profesor nuevoProfe = new Profesor
            {
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                AñosExperiencia = experienciaCalculada,
                MateriaId = idMateria
            };

            repoProfesor.AgregarProfesor(nuevoProfe);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n¡Profesor registrado! (Experiencia calculada: {experienciaCalculada} años)");
            Console.ResetColor();
        }

        static void ListarProfesores()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE PROFESORES ---");
            var lista = repoProfesor.ObtenerProfesores();

            if (lista.Count == 0)
                Console.WriteLine("No hay profesores registrados.");
            foreach (var p in lista)
            {

                Console.WriteLine($"ID: {p.Id} | {p.Nombre} {p.Apellido} | Exp: {p.AñosExperiencia} años | MateriaID: {p.MateriaId}");
            }
        }

        static void MenuDocumentos()
        {
            Console.Clear();
            Console.WriteLine("--- GESTION DE DOCUMENTOS ---");
            Console.WriteLine("1. Documento de ALUMNO");
            Console.WriteLine("2. Documento de PROFESOR");
            string tipo = Console.ReadLine();

            if (tipo == "1")
            {
                int idAlumno = PedirNumero("Ingresa el ID del alumno:");
                if (repoAlumnno.ObtenerPorId(idAlumno) == null)
                {
                    Console.WriteLine("¡Ese alumno no existe!");
                    return;
                }

                AgregarDocumentoAlumno(idAlumno);
            }
            else if (tipo == "2")
            {
                int idProfe = PedirNumero("Ingresa el ID del profesor: ");
                if (repoProfesor.ObtenerPorId(idProfe) == null)
                {
                    Console.WriteLine("¡Ese Profesor no existe!");
                    return;
                }

                AgregarDocumentoProfesor(idProfe);
            }
            else
            {
                Console.WriteLine("Opcion no valida.");
            }
        }

        static void AgregarDocumentoAlumno(int alumnoId)
        {
            Console.Write("Nombre del Documento (ej. Acta, titulo): ");
            string nombreDoc = Console.ReadLine();

            Documento doc = new Documento
            {
                Nombre = nombreDoc,
                Estado = "Entregado",
                FechaEntrega = DateTime.Now,
                PersonaId = alumnoId
            };

            repoDocsAlumno.AgregarDocumento(doc);

            Console.WriteLine("Documento guardado correctamente en el expediente del alumno.");
        }

        static void AgregarDocumentoProfesor(int profeId)
        {
            Console.Write("Nombre del Documento (ej. Cedula, RFC): ");
            string nombreDoc = Console.ReadLine();

            Documento doc = new Documento()
            {
                Nombre = nombreDoc,
                Estado = "Entregado",
                FechaEntrega = DateTime.Now,
                PersonaId = profeId
            };

            repoDocsProfe.AgregarDocumento(doc);
            Console.WriteLine("Documento guardado correctamente en el expediente del profesor.");
        }

        static int PedirNumero(string mensaje)
        {
            int numero;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    return numero;
                }
                Console.WriteLine("Por favor, ingresa un numero valido.");
            }
        }
    }
}
