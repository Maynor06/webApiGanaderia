using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class ProveedorService: IProveedor
    {
        private readonly ApplicationDbContext _context;
        public ProveedorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ProveedorDto>> GetProveedores()
        {
            var proveedores = _context.Proveedors.Select(p => new ProveedorDto
            {
                id = p.IdProveedor,
                nombre = p.Nombre,
            }).ToList();
            return Task.FromResult(proveedores);
        }
    }
}
