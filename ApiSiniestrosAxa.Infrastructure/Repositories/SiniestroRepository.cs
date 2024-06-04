using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Infrastructure.Data.Models;

namespace ApiSiniestrosAxa.Infrastructure.Repositories
{
    public class SiniestroRepository : ISiniestroRepository
    {
        private readonly AppDbContext _context;

        public SiniestroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Siniestro>> GetAllAsync( Siniestro siniestro ) 
        {
            IQueryable<Siniestro> query = _context.Siniestros;

            if (siniestro.IdPersona > 0)
            {
                query = query.Where(p => p.IdPersona == siniestro.IdPersona);
            }

            if (!string.IsNullOrEmpty(siniestro.NumeroExpediente))
            {
                query = query.Where(p => p.NumeroExpediente == siniestro.NumeroExpediente);
            }

            return await query.ToListAsync();
        }

        public async Task<Siniestro> GetSiniestroByUidAsync(Guid? uid)
        {
            return await _context.Siniestros.FirstOrDefaultAsync(s => s.Uid == uid);
        }

        public async Task<Siniestro> GetByIdAsync(long id)
        {
            return await _context.Siniestros.FindAsync(id);
        }

        public async Task AddAsync(Siniestro siniestro)
        {
            _context.Siniestros.Add(siniestro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Siniestro siniestro)
        {
            _context.Entry(siniestro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task AddSiniestroAthentoAsync(Siniestro siniestro)
        {
            throw new NotImplementedException();
        }
    }
}
