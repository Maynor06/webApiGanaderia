using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class InfraestructuraService: IInfraestructura
    {
        private readonly ApplicationDbContext _context;

        public InfraestructuraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<InfraestructuraDto> getRegistros()
        {
            try
            {
                var totalPotreros = _context.Potreros.Count();
                var totalCorrales = _context.Corrals.Count();
                var totalEstablos = _context.Establos.Count();
                var infraestructuraDto = new InfraestructuraDto
                {
                    totalPotreros = totalPotreros,
                    totalCorrales = totalCorrales,
                    totalEstablos = totalEstablos
                };
                return Task.FromResult(infraestructuraDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los registros de infraestructura: " + ex.Message);
            }

        }
    }
}
