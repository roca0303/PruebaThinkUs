using Microsoft.AspNetCore.Mvc;
using PruebaThinkUs.Models;
using PruebaThinkUs.Services;

namespace PruebaThinkUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoGradoController: ControllerBase
    {
        private readonly IAlumnoGradoService _alumnoGradoService;

        public AlumnoGradoController(IAlumnoGradoService alumnoGradoService)
        {
            _alumnoGradoService = alumnoGradoService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<GradoDTO>> Get()
        {
            return Ok(_alumnoGradoService.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<Grado> Get(int id)
        {
            var alumnogrado = _alumnoGradoService.GetById(id);
            if (alumnogrado == null)
            {
                return NotFound();
            }
            return Ok(alumnogrado);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AlumnoGrado alumnogrado)
        {
            _alumnoGradoService.Add(alumnogrado);
            return CreatedAtAction(nameof(Get), new { id = alumnogrado.Id }, alumnogrado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AlumnoGradoUpdateDto alumnogrado)
        {
            if (id != alumnogrado.Id)
            {
                return BadRequest();
            }

            var existingGrado = _alumnoGradoService.GetById(id);
            if (existingGrado == null)
            {
                return NotFound();
            }

            var alumnoGrado = new AlumnoGrado
            {
                Id = alumnogrado.Id,
                AlumnoId = alumnogrado.AlumnoId,
                GradoId = alumnogrado.GradoId,
                Grupo = alumnogrado.Grupo
            };

            try
            {
                _alumnoGradoService.Update(alumnoGrado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

            //_alumnoGradoService.Update(alumnogrado);
            //return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var grado = _alumnoGradoService.GetById(id);
            if (grado == null)
            {
                return NotFound();
            }

            _alumnoGradoService.Delete(id);
            return NoContent();
        }
    }
}
