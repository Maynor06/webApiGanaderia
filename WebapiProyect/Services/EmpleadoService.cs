using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext applicationDb) {
            _context = applicationDb;
        }

        public async Task<Empleado> CreateEmpleado(Empleado empleado)
        {
            try
            {
                _context.Empleados.Add(empleado);
                await  _context.SaveChangesAsync();
                return empleado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el empleado", ex);
            }
        }

        public async Task<List<EmpleadoDTO>> GetAllEmpleados()
        {
            var empleados = await _context.Empleados.Include(e => e.Cargo).ToListAsync();
            var empleadoDtos = empleados.Select(e => new EmpleadoDTO
            {
                ID = e.IdEmpleado,
                NombreCompleto = e.Nombre + e.Apellido,
                Nombre= e.Nombre,
                Apellido = e.Apellido,
                Salario = e.SalarioBase,
                Antiguedad = e.FechaIngreso.HasValue ? CalcularTiempoServicio(e.FechaIngreso.Value.ToDateTime(new TimeOnly()), DateTime.Now) : null,
                FechaIngreso = e.FechaIngreso,
                Cargo = e.Cargo.Nombre
            }).ToList();

            return empleadoDtos;
        }

        public async Task<EmpleadoDTO> GetEmpleadoById(long id)
        {
            var empleado = await _context.Empleados
                .Include(e => e.Cargo)
                .FirstOrDefaultAsync(e => e.IdEmpleado == id);
            return new EmpleadoDTO
            {
                ID = empleado.IdEmpleado,
                NombreCompleto = empleado.Nombre + empleado.Apellido,
                Antiguedad = empleado.FechaIngreso.HasValue ? CalcularTiempoServicio(empleado.FechaIngreso.Value.ToDateTime(new TimeOnly()), DateTime.Now) : null,
                FechaIngreso = empleado.FechaIngreso,
                Salario = empleado.SalarioBase,
                Cargo = empleado.Cargo != null ? empleado.Cargo.Nombre : null,
            };
        }

        public async Task<bool> DeleteEmpleado(long id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            var planillas = _context.Planillas.Where(p => p.EmpleadoId == id);
            _context.Planillas.RemoveRange(planillas);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Empleado?> UpdateEmpleado(long id, Empleado empleado)
        {
            try
            {
                Empleado empleadoFound = await _context.Empleados.FindAsync(id);
                if (empleadoFound == null)
                {
                    return null;
                }
                empleadoFound.Nombre = empleado.Nombre;
                empleadoFound.SalarioBase = empleado.SalarioBase;
                empleadoFound.Apellido = empleado.Apellido;
                empleadoFound.FotoUrl = empleado.FotoUrl;
                await _context.SaveChangesAsync();
                return empleadoFound;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el empleado", ex);
            }
        }

        public async Task<List<EmpleadoDTO>> GetEmpleadosByCargoId(long cargoId)
        {
            var empleados = await _context.Empleados
                .Where(e => e.CargoId == cargoId)
                .Include(e => e.Cargo)
                .ToListAsync();

           List<EmpleadoDTO> empleadoDTOs = empleados.Select(e => new EmpleadoDTO
            {
                ID = e.IdEmpleado,
                NombreCompleto = e.Nombre + e.Apellido,
                Salario = e.SalarioBase,
                Antiguedad = e.FechaIngreso.HasValue ? CalcularTiempoServicio(e.FechaIngreso.Value.ToDateTime(new TimeOnly()), DateTime.Now) : null,
                FechaIngreso = e.FechaIngreso, 
               Cargo = e.Cargo != null ? e.Cargo.Nombre : null,
            }).ToList();

            return empleadoDTOs;

        }

        private static string CalcularTiempoServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            int years = fechaFin.Year - fechaInicio.Year;

            int months = fechaFin.Month - fechaInicio.Month;

            int days = fechaFin.Day - fechaInicio.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(fechaFin.Year, (fechaFin.Month > 1) ? fechaFin.Month - 1 : 12);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            if (years < 0)
            {
                return "Fecha inválida";
            }

            var partes = new List<string>();

            if (years > 0)
                partes.Add($"{years} año{(years > 1 ? "s" : "")}");

            if (months > 0)
                partes.Add($"{months} mes{(months > 1 ? "es" : "")}");

            if (days > 0 || partes.Count == 0) 
                partes.Add($"{days} día{(days != 1 ? "s" : "")}");

            return string.Join(", ", partes);
        }
    }
}
