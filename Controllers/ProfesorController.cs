using Microsoft.AspNetCore.Mvc;
using PruebaThinkUs.Models;
using PruebaThinkUs.Services;

namespace PruebaThinkUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController: ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        // GET: api/empleado
        [HttpGet]
        public ActionResult<IEnumerable<Profesor>> Get()
        {
            return Ok(_profesorService.GetAll());
        }

        // GET: api/empleado/{id}
        [HttpGet("{id}")]
        public ActionResult<Profesor> Get(int id)
        {
            var profesor = _profesorService.GetById(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return Ok(profesor);
        }

        // POST: api/empleado
        [HttpPost]
        public ActionResult Post([FromBody] Profesor profesor)
        {
            _profesorService.Add(profesor);
            return CreatedAtAction(nameof(Get), new { id = profesor.Id }, profesor);
        }

        // PUT: api/empleado/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            var existingProfesor = _profesorService.GetById(id);
            if (existingProfesor == null)
            {
                return NotFound();
            }

            _profesorService.Update(profesor);
            return NoContent();
        }

        // DELETE: api/empleado/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var profesor = _profesorService.GetById(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _profesorService.Delete(id);
            return NoContent();
        }
    }
}
