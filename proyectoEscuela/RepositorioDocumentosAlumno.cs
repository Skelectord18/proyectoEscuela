using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioDocumentosAlumno
    {
        private Dictionary<string, List<string>> documentos = new Dictionary<string, List<string>>();
        private List<string> Requeridos = new List<string>()
        {
            "Acta de Nacimiento",
            "CURP",
            "Certificado de Bachillerato",
            "Comprobante de Domicilio",
            "Fotografia Infantil",
        };

        public void RegistrarDocumentosAlumno(Alumno alumno)
        {
            Console.Clear();
            Console.WriteLine($"=== REGISTRO DE DOCUMENTOS PARA: {alumno.Nombre} ===");
            List<string> entregados = new();
            foreach (var doc in Requeridos)
            {
                Console.WriteLine($"¿Entrego {doc}? (S/N): ");
                var k = Console.ReadKey(true).Key;
                if (k == ConsoleKey.S) entregados.Add(doc);
            }
            documentos[alumno.Documento] = entregados;
            Console.WriteLine("\nDocumentos guardados.");
            Console.ReadKey();
        }
        public void VerificarDocumentos(Alumno alumno)
        {
            Console.Clear();
            Console.WriteLine($"=== DOCUMENTOS DE {alumno.Nombre} ===");

            if (!documentos.ContainsKey(alumno.Documento))
            {
                Console.WriteLine("No hay documentos.");
                Console.ReadKey();
                return;
            }

            var entregados = documentos[alumno.Documento];
            foreach (var doc in Requeridos)
            {
                if (entregados.Contains(doc))
                    Console.WriteLine($"{doc}");
                else
                    Console.WriteLine($"{doc}");
            }
            Console.ReadKey();
        }
    }
}
