using Microsoft.EntityFrameworkCore;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class RazaService: IRaza
    {
        private readonly ApplicationDbContext _context;

        public RazaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Raza>> GetRazasByEspecieIdAsync(long especieId)
        {
            return await _context.Razas
                .Where(r => r.EspecieId == especieId)
                .ToListAsync();

        }

    }
}
