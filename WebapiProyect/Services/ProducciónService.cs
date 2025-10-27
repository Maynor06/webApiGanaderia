using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class ProduccionService: IProduccion
    {
        private readonly ApplicationDbContext _context;

        public ProduccionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProduccionDto> GetProduccionMesLater()
        {
            DateOnly fechaLimite = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
            decimal produccionLeche = _context.ProduccionLeches
                .Sum(p => p.Litros);

            decimal produccionCarne = _context.ProduccionCarnes
                .Sum(p => p.PesoCanal);

            decimal promedioLeche = await _context.ProduccionLeches.AverageAsync(p => p.Litros);

            return new ProduccionDto
            {
                produccionCarne = produccionCarne,
                produccionLecha = produccionLeche,
                promedioLeche = promedioLeche,
            };
            
        }
    }
}
