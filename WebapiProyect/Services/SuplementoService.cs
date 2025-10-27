using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class SuplementoService: Isuplementos
    {

        private readonly ApplicationDbContext _context;

        public SuplementoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SuplementosDto>> GetSuplementosAsync()
        {
            var results = await _context.Suplementos
                .Include(s => s.InventarioSuplementos)
                .ToListAsync();

            var suplementos = results.Select(s => new SuplementosDto
            {
                Id = s.IdSuplemento,
                Nombre = s.Nombre,
                Nutrientes = s.Nutrientes,
                tipo = s.Nutrientes,
                stock = s.InventarioSuplementos.Sum(i => i.Cantidad).ToString(),
                FechaVencimiento = s.InventarioSuplementos.Min(i => i.FechaVencimiento)

            }).ToList();
            

            return suplementos;
        }
    }
}
