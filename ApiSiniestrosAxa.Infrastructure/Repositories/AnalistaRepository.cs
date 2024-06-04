using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Infrastructure.Data;
using ApiSiniestrosAxa.Infrastructure.Data.Models;

namespace ApiSiniestrosAxa.Infrastructure.Repositories
{
    public class AnalistaRepository : IAnalistaRepository
    {
        private readonly AppDbContext _context;

        public AnalistaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analista>> GetAllAsync()
        {
            return await _context.Analistas.ToListAsync();
        }

        public async Task<Analista> GetByIdAsync(long id)
        {
            return await _context.Analistas.FindAsync(id);
        }

        public async Task<Analista> GetAnalistaByEmailAsync(string email)
        {
            return await _context.Analistas.FirstOrDefaultAsync(a => a.Correo == email);
        }

        public async Task<Analista> AddAsync(Analista analista)
        {
            _context.Analistas.Add(analista);
            await _context.SaveChangesAsync();
            return analista;
        }

        public async Task UpdateAsync(Analista analista)
        {
            _context.Entry(analista).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
