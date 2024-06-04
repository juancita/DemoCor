using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Core.Interfaces
{
    public interface IAnalistaRepository
    {
        Task<IEnumerable<Analista>> GetAllAsync();
        Task<Analista> GetByIdAsync(long id);
        Task<Analista> AddAsync(Analista analista);
        Task UpdateAsync(Analista analista);
        Task<Analista> GetAnalistaByEmailAsync(string email);
    }
}
