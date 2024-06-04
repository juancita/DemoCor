using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Application.Services
{
    public class MovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientoService(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        public async Task<IEnumerable<Movimiento>> GetAllMovimientosAsync()
        {
            return await _movimientoRepository.GetAllAsync();
        }

        public async Task<Movimiento> GetMovimientoByIdAsync(long id)
        {
            return await _movimientoRepository.GetByIdAsync(id);
        }

        public async Task AddMovimientoAsync(Movimiento movimiento)
        {
            await _movimientoRepository.AddAsync(movimiento);
        }

        public async Task UpdateMovimientoAsync(Movimiento movimiento)
        {
            await _movimientoRepository.UpdateAsync(movimiento);
        }
    }
}
