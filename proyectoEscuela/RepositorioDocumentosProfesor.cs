using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioDocumentosProfesor
    {
        private Dictionary<string, List<string>> documentos = new();
        private List<string> Requeridos = new List<string>()
        {
            "Titulo Profesional",
            "Cedula Profesional",
            "Curriculum Vitae",
            "Carta de No Antecedentes Penales",
            "Comprobante de Experiencia Laboral",
        };

        public void RegistrarDocumentosProfesor(Profesor profesor)
        {
            Console.Clear();
            Console.WriteLine($"=== DOCUMENTOS DEL PROFESOR: {profesor.Nombre} ===");
            List<string> entregados = new();
            foreach (var doc in Requeridos)
            {
                Console.WriteLine($"\n¿El profesor entrego {doc}? (S/N): ");
                var k = Console.ReadKey(true).Key;

                if (k == ConsoleKey.S) entregados.Add(doc);
            }
            documentos[profesor.Documento] = entregados;
            Console.WriteLine("\nDocumentos guardados.");
            Console.ReadKey();
        }
        public void VerificarDocumentos(Profesor profesor)
        {
            Console.Clear();
            Console.WriteLine($"=== DOCUMENTOS DE {profesor.Nombre} ===");

            if (!documentos.ContainsKey(profesor.Documento))
            {
                Console.WriteLine("No hay documentos.");
                Console.ReadKey();
                return;
            }
            var entregados = documentos[profesor.Documento];

            foreach (var doc in Requeridos)
            {
                bool existe = false;
                foreach (var e in entregados)
                {
                    if (e.Contains(doc))
                    {
                        Console.WriteLine($" {e}");
                        existe = true;
                    }
                }
                if (!existe) Console.WriteLine($"{doc}");
                Console.WriteLine($" {doc} ");
            }
            Console.ReadKey();
        }
    }
}