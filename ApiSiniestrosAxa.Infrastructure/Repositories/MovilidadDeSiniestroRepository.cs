using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Infrastructure.Repositories
{
    public class MovilidadDeSiniestroRepository : IMovilidadDeSiniestroRepository
    {
        private readonly AppDbContext _context;

        public MovilidadDeSiniestroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovilidadDeSiniestro>> GetAllAsync(MovilidadDeSiniestro movilidadDeSiniestro)
        {
            IQueryable<MovilidadDeSiniestro> query = _context.MovilidadDeSiniestros;

            if (!string.IsNullOrEmpty(movilidadDeSiniestro.Placa))
            {
                query = query.Where(p => p.Placa == movilidadDeSiniestro.Placa);
            }

            return await query.ToListAsync();

        }

        public async Task<MovilidadDeSiniestro> GetByIdAsync(long id)
        {
            return await _context.MovilidadDeSiniestros.FindAsync(id);
        }

        public async Task<MovilidadDeSiniestro> AddAsync(MovilidadDeSiniestro movilidadDeSiniestro)
        {
            _context.MovilidadDeSiniestros.Add(movilidadDeSiniestro);
            await _context.SaveChangesAsync();
            return movilidadDeSiniestro;
        }

        public async Task UpdateAsync(MovilidadDeSiniestro persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
