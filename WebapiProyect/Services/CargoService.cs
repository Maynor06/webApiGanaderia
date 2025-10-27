using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class CargoService: ICargo
    {
        private readonly ApplicationDbContext _context;
        public CargoService(ApplicationDbContext applicationDb) {
            _context = applicationDb;

        }

        public async Task<List<CargoDto>> GetAllCargos()
        {
            var cargos = await _context.Cargos
                .Include(c => c.Empleados)
                .ToListAsync();
            var cargoDtos = cargos.Select(c => new CargoDto
            {
                IdCargo = c.IdCargo,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                SalarioBase = c.Empleados.Select(e => e.SalarioBase).FirstOrDefault().ToString()
            }).ToList();
            return cargoDtos;
        }

        public async Task<Cargo> CreateCargo(Cargo cargo)
        {
            try
            {
                Cargo cargo1 = new()
                {
                    Nombre = cargo.Nombre,
                    Descripcion = cargo.Descripcion
                };

                _context.Cargos.Add(cargo1);
                await  _context.SaveChangesAsync();
                return cargo1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el cargo", ex);
            }
        }

    }
}
