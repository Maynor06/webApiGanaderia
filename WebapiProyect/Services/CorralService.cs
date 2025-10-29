using Microsoft.EntityFrameworkCore;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class CorralService : ICorral
    {
        private readonly ApplicationDbContext _context;

        public CorralService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Corral> CreateCorralAsync(Corral corral)
        {
            try
            {
                await _context.Corrals.AddAsync(corral);
                await _context.SaveChangesAsync();
                return corral;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el corral: " + ex.Message);
            }

        }

        public Task<List<Corral>> GetAllCorralesAsync()
        {
            try
            {
                var corrales = _context.Corrals.ToListAsync();
                return corrales;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los corrales: " + ex.Message);
            }
        }

        public async Task<Corral> UpdateCorralAsync(long id, Corral corral)
        {
            try
            {
                var existingCorral = await _context.Corrals.FindAsync(id);
                if (existingCorral == null)
                {
                    return null;
                }
                existingCorral.Nombre = corral.Nombre;
                existingCorral.Capacidad = corral.Capacidad;
                existingCorral.Estado = corral.Estado;
                _context.Corrals.Update(existingCorral);
                _context.SaveChangesAsync();
                return existingCorral;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el corral: " + ex.Message);
            }
        }
    }
}
