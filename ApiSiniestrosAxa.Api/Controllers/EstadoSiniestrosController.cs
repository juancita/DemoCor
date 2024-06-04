using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Application.Services;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoSiniestrosController : ControllerBase
    {
        private readonly EstadoSiniestroService _estadoSiniestroService;

        public EstadoSiniestrosController(EstadoSiniestroService estadoSiniestroService)
        {
            _estadoSiniestroService = estadoSiniestroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoSiniestro>>> GetEstadoSiniestros()
        {
            var estadoSiniestros = await _estadoSiniestroService.GetAllEstadoSiniestrosAsync();
            return Ok(estadoSiniestros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoSiniestro>> GetEstadoSiniestro(long id)
        {
            var estadoSiniestro = await _estadoSiniestroService.GetEstadoSiniestroByIdAsync(id);
            if (estadoSiniestro == null)
            {
                return NotFound();
            }
            return Ok(estadoSiniestro);
        }

        [HttpPost]
        public async Task<ActionResult<EstadoSiniestro>> PostEstadoSiniestro(EstadoSiniestro estadoSiniestro)
        {
            await _estadoSiniestroService.AddEstadoSiniestroAsync(estadoSiniestro);
            return CreatedAtAction(nameof(GetEstadoSiniestro), new { id = estadoSiniestro.IdEstado }, estadoSiniestro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoSiniestro(long id, EstadoSiniestro estadoSiniestro)
        {
            if (id != estadoSiniestro.IdEstado)
            {
                return BadRequest();
            }

            await _estadoSiniestroService.UpdateEstadoSiniestroAsync(estadoSiniestro);
            return NoContent();
        }
    }
}
