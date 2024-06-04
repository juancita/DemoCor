using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Application.Services
{
    public class MovilidadDeSiniestroService
    {
        private readonly IMovilidadDeSiniestroRepository _movilidadDeSiniestroRepository;

        public MovilidadDeSiniestroService(IMovilidadDeSiniestroRepository movilidadDeSiniestroRepository)
        {
            _movilidadDeSiniestroRepository = movilidadDeSiniestroRepository;
        }

        public async Task<IEnumerable<MovilidadDeSiniestro>> GetAllMovilidadDeSiniestrosAsync(MovilidadDeSiniestro movilidadDeSiniestro)
        {
            return await _movilidadDeSiniestroRepository.GetAllAsync(movilidadDeSiniestro);
        }

        public async Task<MovilidadDeSiniestro> GetMovilidadDeSiniestroByIdAsync(long id)
        {
            return await _movilidadDeSiniestroRepository.GetByIdAsync(id);
        }

        public async Task<MovilidadDeSiniestro> AddMovilidadDeSiniestroAsync(MovilidadDeSiniestro movilidadDeSiniestroRepository)
        {
            return await _movilidadDeSiniestroRepository.AddAsync(movilidadDeSiniestroRepository);
        }

        public async Task UpdateMovilidadDeSiniestroAsync(MovilidadDeSiniestro movilidadDeSiniestroRepository)
        {
            await _movilidadDeSiniestroRepository.UpdateAsync(movilidadDeSiniestroRepository);
        }
    }
}
