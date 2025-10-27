using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class EspecieService: IEspecie
    {
        private readonly ApplicationDbContext _context;
        public EspecieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EspecieDto>> GetAllEspeciesAsync()
        {
            var especies = await _context.Especies
                .Include(e => e.Razas)
                .ToListAsync();

            var especieDtos = especies.Select(e => new EspecieDto
            {
                IdEspecie = e.IdEspecie,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Razas = e.Razas.Select(r => new RazaDto
                {
                    Id = r.IdRaza,
                    Nombre = r.Nombre,
                }).ToList()
            }
            ).ToList();

            return especieDtos;
        }


    }
}
