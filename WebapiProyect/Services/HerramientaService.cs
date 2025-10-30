using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class HerramientaService: IHerramienta
    {
        private readonly ApplicationDbContext _context;

        public async Task<Herramientum> ActualizarHerramienta(long id, Herramientum herramienta)
        {
            try
            {
                var existingHerramienta = _context.Herramienta.Find(id);
                if (existingHerramienta == null)
                {
                    throw new KeyNotFoundException("Herramienta no encontrada");
                }
                existingHerramienta.Nombre = herramienta.Nombre;
                existingHerramienta.Tipo = herramienta.Tipo;
                existingHerramienta.Estado = herramienta.Estado;
                existingHerramienta.FechaAdquisicion = herramienta.FechaAdquisicion;
                _context.Herramienta.Update(existingHerramienta);
                await _context.SaveChangesAsync();
                return existingHerramienta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la herramienta", ex);
            }
        }

        public async Task<Herramientum> CreateHerramienta(Herramientum herramienta)
        {
            try
            {
                _context.Herramienta.Add(herramienta);
                await _context.SaveChangesAsync();
                return herramienta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la herramienta", ex);
            }
        }


        public async Task<List<HerramientaDto>> GetHerramientasConCantidadDisponible()
        {
            try
            {
                var results = await _context.Herramienta
                    .Include(h => h.InventarioHerramienta).ToListAsync();

                var herramientasDto = results.Select(h => new HerramientaDto
                {
                    IdHerramienta = h.IdHerramienta,
                    Nombre = h.Nombre,
                    Tipo = h.Tipo,
                    Estado = h.Estado,
                    FechaAdquisicion = h.FechaAdquisicion,
                    CantidadDisponible = h.InventarioHerramienta.Sum(ih => ih.Cantidad)
                }).ToList();
                return herramientasDto;
            }catch (Exception ex)
            {
                throw new Exception("Error al obtener las herramientas con cantidad disponible", ex);
            }
        }
    }
}
