using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;

namespace ApiSiniestrosAxa.Application.Services
{
    public class PersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<IEnumerable<Persona>> GetAllPersonasAsync(Persona persona)
        {
            return await _personaRepository.GetAllAsync(persona);
        }

        public async Task<Persona> GetPersonaByIdAsync(long id)
        {
            return await _personaRepository.GetByIdAsync(id);
        }

        public async Task<Persona> AddPersonaAsync(Persona persona)
        {
            return await _personaRepository.AddAsync(persona);
        }

        public async Task UpdatePersonaAsync(Persona persona)
        {
            await _personaRepository.UpdateAsync(persona);
        }
        public async Task<Persona> GetPersonaByDocumentAsync(Persona persona)
        {
            return await _personaRepository.GetByDocumentoAsync(persona);
        }

    }
}
