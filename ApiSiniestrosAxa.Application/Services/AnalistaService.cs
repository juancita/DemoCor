using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Application.Services
{
    public class AnalistaService
    {
        private readonly IAnalistaRepository _analistaRepository;

        public AnalistaService(IAnalistaRepository analistaRepository)
        {
            _analistaRepository = analistaRepository;
        }

        public async Task<IEnumerable<Analista>> GetAllAnalistasAsync()
        {
            return await _analistaRepository.GetAllAsync();
        }

        public async Task<Analista> GetAnalistaByIdAsync(long id)
        {
            return await _analistaRepository.GetByIdAsync(id);
        }

        public async Task<Analista> AddAnalistaAsync(Analista analista)
        {
            return await _analistaRepository.AddAsync(analista);
        }

        public async Task UpdateAnalistaAsync(Analista analista)
        {
            await _analistaRepository.UpdateAsync(analista);
        }

        public async Task<Analista> GetAnalistaByEmailAsync(string email)
        {
            return await _analistaRepository.GetAnalistaByEmailAsync(email);
        }
    }
}
