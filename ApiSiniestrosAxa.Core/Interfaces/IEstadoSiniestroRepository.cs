using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Core.Interfaces
{
    public interface IEstadoSiniestroRepository
    {
        Task<IEnumerable<EstadoSiniestro>> GetAllAsync();
        Task<EstadoSiniestro> GetByIdAsync(long id);
        Task AddAsync(EstadoSiniestro estadoSiniestro);
        Task UpdateAsync(EstadoSiniestro estadoSiniestro);
        Task<EstadoSiniestro> GetByStateAsync(string state);

    }
}
