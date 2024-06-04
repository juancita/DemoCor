using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Application.Services;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Application.External;

namespace ApiSiniestrosAxa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly MovimientoService _movimientoService;

        public MovimientosController(MovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimientos()
        {
            var movimientos = await _movimientoService.GetAllMovimientosAsync();
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(long id)
        {
            var movimiento = await _movimientoService.GetMovimientoByIdAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }
            return Ok(movimiento);
        }

        [HttpPost]
        public async Task<ActionResult<Movimiento>> PostMovimiento(Movimiento movimiento)
        {
            await _movimientoService.AddMovimientoAsync(movimiento);
            return CreatedAtAction(nameof(GetMovimiento), new { id = movimiento.IdMovimiento }, movimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimiento(long id, Movimiento movimiento)
        {
            if (id != movimiento.IdMovimiento)
            {
                return BadRequest();
            }

            await _movimientoService.UpdateMovimientoAsync(movimiento);
            return NoContent();
        }
    }
}
