using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Infrastructure.Data.Models;

namespace ApiSiniestrosAxa.Infrastructure.Repositories
{
    public class EstadoSiniestroRepository : IEstadoSiniestroRepository
    {
        private readonly AppDbContext _context;

        public EstadoSiniestroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadoSiniestro>> GetAllAsync()
        {
            return await _context.EstadoSiniestros.ToListAsync();
        }

        public async Task<EstadoSiniestro> GetByIdAsync(long id)
        {
            return await _context.EstadoSiniestros.FindAsync(id);
        }

        public async Task<EstadoSiniestro> GetByStateAsync(string state)
        {
            return await _context.EstadoSiniestros.FirstOrDefaultAsync( e => e.EstadoSiniestro1 == state);
        }

        public async Task AddAsync(EstadoSiniestro estadoSiniestro)
        {
            _context.EstadoSiniestros.Add(estadoSiniestro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EstadoSiniestro estadoSiniestro)
        {
            _context.Entry(estadoSiniestro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
