using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Application.Services
{
    public class EstadoSiniestroService
    {
        private readonly IEstadoSiniestroRepository _estadoSiniestroRepository;

        public EstadoSiniestroService(IEstadoSiniestroRepository estadoSiniestroRepository)
        {
            _estadoSiniestroRepository = estadoSiniestroRepository;
        }

        public async Task<IEnumerable<EstadoSiniestro>> GetAllEstadoSiniestrosAsync()
        {
            return await _estadoSiniestroRepository.GetAllAsync();
        }

        public async Task<EstadoSiniestro> GetEstadoSiniestroByIdAsync(long id)
        {
            return await _estadoSiniestroRepository.GetByIdAsync(id);
        }

        public async Task<EstadoSiniestro> GetEstadoSiniestroByStateAsync(string state)
        {
            return await _estadoSiniestroRepository.GetByStateAsync(state);
        }

        public async Task AddEstadoSiniestroAsync(EstadoSiniestro estadoSiniestro)
        {
            await _estadoSiniestroRepository.AddAsync(estadoSiniestro);
        }

        public async Task UpdateEstadoSiniestroAsync(EstadoSiniestro estadoSiniestro)
        {
            await _estadoSiniestroRepository.UpdateAsync(estadoSiniestro);
        }
    }
}
