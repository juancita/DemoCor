using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Core.Interfaces
{
    public interface ISiniestroRepository
    {
        Task<IEnumerable<Siniestro>> GetAllAsync(Siniestro siniestro);
        Task<Siniestro> GetSiniestroByUidAsync(Guid? uid);
        Task<Siniestro> GetByIdAsync(long id);
        Task AddAsync(Siniestro siniestro);
        Task UpdateAsync(Siniestro siniestro);
    }
}
