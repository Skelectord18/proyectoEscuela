using Microsoft.AspNetCore.Mvc;
using System;
using UniversidadPOO;

namespace Api_Rest.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProfesoresController : ControllerBase
    {
        private readonly RepositorioProfesor _repositorioProfesor = new RepositorioProfesor();
        [HttpGet]
        public string GetAll()
        {
            return " Lista de Todos los Profesores Disponibles";
        }
        [HttpGet("{Id}")]
        public string GetById(int id)
        {
            return $"Datos del profesor con el ID: {id}";
        }

        [HttpPost]
        public IActionResult Create([FromBody] Profesor NuevoProfesor)
        {
            try
            {
                _repositorioProfesor.Agregar(NuevoProfesor);
                return Ok(new { mensaje = $"Acabas de guardar al alumno: {NuevoProfesor.Nombre}" });
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
            return $"Actualizacion de los datos del profesor {id}";
        }
        [HttpDelete]
        [HttpDelete("{Id}")]
        public string Delete(int id)
        {
            return $"El profesor {id} ha sido dada de baja";
        }
    }
}