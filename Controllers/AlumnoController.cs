using Microsoft.AspNetCore.Mvc;
using PruebaThinkUs.Models;
using PruebaThinkUs.Services;

namespace PruebaThinkUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController: ControllerBase
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        // GET: api/empleado
        [HttpGet]
        public ActionResult<IEnumerable<Alumno>> Get()
        {
            return Ok(_alumnoService.GetAll());
        }

        // GET: api/empleado/{id}
        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            var alumno = _alumnoService.GetById(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        // POST: api/empleado
        [HttpPost]
        public ActionResult Post([FromBody] Alumno alumno)
        {
            _alumnoService.Add(alumno);
            return CreatedAtAction(nameof(Get), new { id = alumno.Id }, alumno);
        }

        // PUT: api/empleado/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            var existingEmpleado = _alumnoService.GetById(id);
            if (existingEmpleado == null)
            {
                return NotFound();
            }

            _alumnoService.Update(alumno);
            return NoContent();
        }

        // DELETE: api/empleado/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var alumno = _alumnoService.GetById(id);
            if (alumno == null)
            {
                return NotFound();
            }

            _alumnoService.Delete(id);
            return NoContent();
        }
    }
}
