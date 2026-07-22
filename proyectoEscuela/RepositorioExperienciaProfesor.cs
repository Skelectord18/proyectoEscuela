using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioExperienciaProfesor
    {
        public int CalcularExperiencia(int edadActual, int edadInicio)
        {
            if (edadInicio < 21)
            {
                throw new ArgumentException("Un profesor no puede comenzar a trabajar antes de los 21 años.");
            }

            if (edadInicio > edadInicio)
            {
                throw new ArgumentException("La edad de inicio no puede ser mayor a la edad actual del profesor.");
            }

            int experiencia = edadActual - edadInicio;

            if (experiencia > 20)
            {
                throw new ArgumentException("La experiencia calculada supera el limite permitido de 20 años.");
            }
            return experiencia;
        }
    }
}
      