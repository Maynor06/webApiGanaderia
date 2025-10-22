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

        public async Task<List<Cargo>> GetAllCargos()
        {
            return _context.Cargos.ToList();
        }

        public async Task<Cargo> CreateCargo(Cargo cargo)
        {
            try
            {
                _context.Cargos.Add(cargo);
                await  _context.SaveChangesAsync();
                return cargo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el cargo", ex);
            }
        }

    }
}
