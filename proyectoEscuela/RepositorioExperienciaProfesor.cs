using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioExperienciaProfesor
    {
        public int CalcularExperiencia(Profesor profesor)
        {
            Console.WriteLine("¿A que edad comenzo a trabajar? (minimo 21): ");
            int edadInicio = ValidarNumero("Edad de inicio");
            if (edadInicio < 21)
            {
                Console.WriteLine("Un profesor no puede comenzar antes de los 21 años.");
                return -1;
            }
            if (edadInicio > profesor.Edad)
            {
                Console.WriteLine("La edad de inicio no puede ser mayor a su edad actual.");
                return -1;
            }

            int experiencia = profesor.Edad - edadInicio;

            if (experiencia > 20)
            {
                Console.WriteLine("La experiencia no puede superar 20 años.");
                return -1;
            }
            return experiencia;
        }
        private int ValidarNumero(string campo)
        {
            int numero;
            while (true)
            {
                if
                    (int.TryParse(Console.ReadLine(), out numero))
                    return numero;
                Console.WriteLine($"Entrada invalida. Ingrese numero para {campo}: ");
            }
        }
    }
}


           