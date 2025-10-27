using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class CapacitacionService: ICapacitacion
    {
        private readonly ApplicationDbContext _context;

        public CapacitacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Capacitacion> CreateCapacitacion(Capacitacion capacitacion)
        {
            try
            {
                _context.Capacitacions.Add(capacitacion);
                await _context.SaveChangesAsync();
                return capacitacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la capacitacion", ex);
            }
        }

        public async Task<List<CapacitacionDto>> GetAllCapacitaciones()
        {
           
                var capacitaciones = await _context.Capacitacions.Include(c => c.Empleado).ToListAsync();
                var capacitacionDtos = capacitaciones.Select(c => new CapacitacionDto
                {
                    Fecha = c.Fecha,
                    IdCapacitacion = c.IdCapacitacion,
                    NombreCapacitacion = c.Nombre,
                    Tema = c.Tema,
                    nombreEmpleado = c.Empleado.Nombre != null ? c.Empleado.Nombre : null
                }).ToList();

            return capacitacionDtos;
        }

        public async Task<Capacitacion> UpdateCapacitacion(long id, Capacitacion capacitacion)
        {
            try
            {
                Capacitacion capacitacionFound = await _context.Capacitacions.FindAsync(id);
                if (capacitacionFound == null)
                {
                    return null;
                }
                capacitacionFound.EmpleadoId = capacitacion.EmpleadoId;
                capacitacionFound.Tema = capacitacion.Tema;
                capacitacionFound.Nombre = capacitacion.Nombre;
                capacitacionFound.Fecha = capacitacion.Fecha;
                await _context.SaveChangesAsync();
                return capacitacionFound;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el empleado", ex);
            }
        }

    }
}
