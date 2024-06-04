using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Core.Interfaces
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> GetAllAsync();
        Task<Movimiento> GetByIdAsync(long id);
        Task AddAsync(Movimiento movimiento);
        Task UpdateAsync(Movimiento movimiento);
    }
}