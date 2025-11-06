using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class ProductoService : IProducto
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ProductoDto>> GetProductos()
        {
            var productos = _context.Productos.Select(p => new ProductoDto
            {
                IdProducto = p.IdProducto,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                PrecioBase = p.PrecioBase,
                Tipo = p.Tipo,
                unidad = p.Unidad
            }).ToList();
            return Task.FromResult(productos);
        }
    }
}
