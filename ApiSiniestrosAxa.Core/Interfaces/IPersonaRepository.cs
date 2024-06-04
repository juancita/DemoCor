using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Core.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync(Persona persona);
        Task<Persona> GetByIdAsync(long id);
        Task<Persona> AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task<Persona> GetByDocumentoAsync(Persona persona);
    }
}
