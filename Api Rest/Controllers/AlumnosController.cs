using Microsoft.AspNetCore.Mvc;
using System;
using UniversidadPOO;

namespace Api_Rest.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class AlumnosController : ControllerBase
    {
        private readonly RepositorioAlumno _repositorioAlumno = new RepositorioAlumno();
        [HttpGet]
        public string GetAll()
        {
            return " Lista de Todos los Alumnos Disponibles";
        }
        [HttpGet("{Id}")]
        public string GetById(int id)
        {
            return $"Datos del alumno con el ID: {id}";
        }

        [HttpPost]
        public IActionResult Create([FromBody] Alumno NuevoAlumno)
        {
            try
            {
                _repositorioAlumno.Agregar(NuevoAlumno);
                return Ok(new { mensaje = $"Acabas de guardar al alumno: {NuevoAlumno.Nombre}" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar en la base de datos: {ex.Message}");
            }
        }
        [HttpPut]
        [HttpPut("{Id}")]
        public string Update(int id, [FromBody] string DatosCompletos)
        {
            return $"Actualizacion de los datos del alumno {id}";
        }
        [HttpDelete]
        [HttpDelete("{Id}")]
        public string Delete(int id)
        {
            return $"El alumno {id} ha sido dada de baja";
        }
    }
}