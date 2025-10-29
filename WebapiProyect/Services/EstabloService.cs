using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class EstabloService : IEstablo
    {
        private readonly ApplicationDbContext _context;

        public EstabloService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Establo> CreateEstabloAsync(Establo establo)
        {
            try
            {
                await _context.Establos.AddAsync(establo);
                await _context.SaveChangesAsync();
                return establo;
            }catch (Exception ex)
            {
                throw new Exception("Error al crear el establo: " + ex.Message);
            }

        }

        public async Task<List<EstabloDto>> GetAllEstablosAsync()
        {
            try
            {
                var establos = await _context.Establos.Include(e => e.Empleado).ToListAsync();
                var establosDto = establos.Select(e => new EstabloDto
                {
                    IdEstablo = e.IdEstablo,
                    Nombre = e.Nombre,
                    Capacidad = e.Capacidad,
                    nombreEncargado = e.Empleado != null ? e.Empleado.Nombre + " " + e.Empleado.Apellido : "Sin Encargado"
                }).ToList();
                return establosDto;
            } catch (Exception ex)
            {
                throw new Exception("Error al obtener los establos: " + ex.Message);
            }
        }

        public async Task<Establo> UpdateEstabloAsync(long id, Establo establo)
        {
            try
            {
                var existingEstablo = await _context.Establos.FindAsync(id);
                if (existingEstablo == null)
                {
                    return null;
                }
                existingEstablo.Nombre = establo.Nombre;
                existingEstablo.Capacidad = establo.Capacidad;
                existingEstablo.Nombre = establo.Nombre;
                existingEstablo.EmpleadoId = establo.EmpleadoId;        
                _context.Establos.Update(existingEstablo);
                await _context.SaveChangesAsync();
                return existingEstablo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el establo: " + ex.Message);

            }
        }
    }
}
