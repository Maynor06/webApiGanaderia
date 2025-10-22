using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class EmpleadoService: IEmpleadoService
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

        public async Task<List<Empleado>> GetAllEmpleados()
        {
            return _context.Empleados.ToList();
        }

        public async Task<Empleado?> GetEmpleadoById(long id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<bool> DeleteEmpleado(long id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;
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

        public async Task<List<Empleado>> GetEmpleadosByCargoId(long cargoId)
        {
            return _context.Empleados.Where(e => e.CargoId == cargoId).ToList();
        }

    }
}
