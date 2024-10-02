using Microsoft.AspNetCore.Mvc;
using PruebaThinkUs.Models;
using PruebaThinkUs.Services;

namespace PruebaThinkUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController: ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/empleado
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> Get()
        {
            return Ok(_empleadoService.GetAll());
        }

        // GET: api/empleado/{id}
        [HttpGet("{id}")]
        public ActionResult<Empleado> Get(int id)
        {
            var empleado = _empleadoService.GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        // POST: api/empleado
        [HttpPost]
        public ActionResult Post([FromBody] Empleado empleado)
        {
            _empleadoService.Add(empleado);
            return CreatedAtAction(nameof(Get), new { id = empleado.Id }, empleado);
        }

        // PUT: api/empleado/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            var existingEmpleado = _empleadoService.GetById(id);
            if (existingEmpleado == null)
            {
                return NotFound();
            }

            _empleadoService.Update(empleado);
            return NoContent();
        }

        // DELETE: api/empleado/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var empleado = _empleadoService.GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _empleadoService.Delete(id);
            return NoContent();
        }
    }
}
