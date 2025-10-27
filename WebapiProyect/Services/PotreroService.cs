using Microsoft.EntityFrameworkCore;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class PotreroService: Ipotrero
    {
        private readonly ApplicationDbContext _context;

        public PotreroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Potrero>> GetAllPotrerosAsync()
        {
            var potreros = await _context.Potreros.ToListAsync();
            return potreros;
        }

        public async Task<Potrero> CreatePotreroAsync(Potrero potrero)
        {
            try
            {
                _context.Potreros.AddAsync(potrero);
                await _context.SaveChangesAsync();
                return potrero;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el potrero", ex);
            }

        }

        public async Task<Potrero> UpdatePotreroAsync(long id, Potrero potrero)
        {
            try
            {
                Potrero potreroFound = await _context.Potreros.FindAsync(id);
                if (potreroFound == null)
                {
                    return null;
                }
                potreroFound.Nombre = potrero.Nombre;
                potreroFound.Hectareas = potrero.Hectareas;
                potreroFound.Capacidad = potrero.Capacidad;
                potreroFound.Estado = potrero.Estado;
                await _context.SaveChangesAsync();
                return potreroFound;

            } catch (Exception ex) {
                throw new Exception("Error al actualizar el potrero", ex);
            }
        }

        public async Task<bool> DeletePotreroAsync(long id)
        {
            var potrero = await _context.Potreros.FindAsync(id);
            if (potrero == null) return false;
            _context.Potreros.Remove(potrero);
            await _context.SaveChangesAsync(); 
            return true;
        }

    }
}
