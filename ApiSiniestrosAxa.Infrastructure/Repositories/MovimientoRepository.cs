using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Infrastructure.Data.Models;

namespace ApiSiniestrosAxa.Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly AppDbContext _context;

        public MovimientoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            return await _context.Movimientos.ToListAsync();
        }

        public async Task<Movimiento> GetByIdAsync(long id)
        {
            return await _context.Movimientos.FindAsync(id);
        }

        public async Task AddAsync(Movimiento movimiento)
        {
            _context.Movimientos.Add(movimiento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimiento movimiento)
        {
            _context.Entry(movimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
