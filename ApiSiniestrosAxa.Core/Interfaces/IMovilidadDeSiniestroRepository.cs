
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Core.Interfaces
{
    public interface IMovilidadDeSiniestroRepository
    {
        Task<IEnumerable<MovilidadDeSiniestro>> GetAllAsync(MovilidadDeSiniestro movilidadDeSiniestro);
        Task<MovilidadDeSiniestro> GetByIdAsync(long id);
        Task<MovilidadDeSiniestro> AddAsync(MovilidadDeSiniestro movilidadDeSiniestro);
        Task UpdateAsync(MovilidadDeSiniestro movilidadDeSiniestro);
    }
}
