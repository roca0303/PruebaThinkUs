using Microsoft.AspNetCore.Mvc;
using PruebaThinkUs.Models;
using PruebaThinkUs.Services;

namespace PruebaThinkUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController: ControllerBase
    {
        private readonly IGradoService _gradoService;

        public GradoController(IGradoService gradoService)
        {
            _gradoService = gradoService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<GradoDTO>> Get()
        {
            return Ok(_gradoService.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<Grado> Get(int id)
        {
            var grado = _gradoService.GetById(id);
            if (grado == null)
            {
                return NotFound();
            }
            return Ok(grado);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Grado grado)
        {
            _gradoService.Add(grado);
            return CreatedAtAction(nameof(Get), new { id = grado.Id }, grado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Grado grado)
        {
            if (id != grado.Id)
            {
                return BadRequest();
            }

            var existingGrado = _gradoService.GetById(id);
            if (existingGrado == null)
            {
                return NotFound();
            }

            _gradoService.Update(grado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var grado = _gradoService.GetById(id);
            if (grado == null)
            {
                return NotFound();
            }

            _gradoService.Delete(id);
            return NoContent();
        }
    }
}
