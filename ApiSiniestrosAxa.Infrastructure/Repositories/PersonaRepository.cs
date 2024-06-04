using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiSiniestrosAxa.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync(Persona persona)
        {
            IQueryable<Persona> query = _context.Personas;

            if (persona.IdTipoDocumento.HasValue)
            {
                query = query.Where(p => p.IdTipoDocumento == persona.IdTipoDocumento);
            }

            if (!string.IsNullOrEmpty(persona.Documento))
            {
                query = query.Where(p => p.Documento == persona.Documento);
            }

            return await query.ToListAsync();

        }

        public async Task<Persona> GetByIdAsync(long id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<Persona> AddAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Persona> GetByDocumentoAsync(Persona persona)
        {
            return _context.Personas.FirstOrDefault(p => p.Documento == persona.Documento && p.IdTipoDocumento == persona.IdTipoDocumento);
        }

    }
}
