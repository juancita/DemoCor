using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Application.Services;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalistasController : ControllerBase
    {
        private readonly AnalistaService _analistaService;

        public AnalistasController(AnalistaService analistaService)
        {
            _analistaService = analistaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analista>>> GetAnalistas()
        {
            var analistas = await _analistaService.GetAllAnalistasAsync();
            return Ok(analistas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Analista>> GetAnalista(long id)
        {
            var analista = await _analistaService.GetAnalistaByIdAsync(id);
            if (analista == null)
            {
                return NotFound();
            }
            return Ok(analista);
        }

        [HttpPost]
        public async Task<ActionResult<Analista>> PostAnalista(Analista analista)
        {
            await _analistaService.AddAnalistaAsync(analista);
            return CreatedAtAction(nameof(GetAnalista), new { id = analista.IdAnalista }, analista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalista(long id, Analista analista)
        {
            if (id != analista.IdAnalista)
            {
                return BadRequest();
            }

            await _analistaService.UpdateAnalistaAsync(analista);
            return NoContent();
        }
    }
}
