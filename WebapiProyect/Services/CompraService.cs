using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class CompraService: ICompra
    {
        private readonly ApplicationDbContext _context;

        public CompraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ComprasDto>> GetComprasAsync()
        {
            var results = await _context.Compras
                .Include(c => c.Proveedor).ToListAsync();

            var compras = results.Select(compra => new ComprasDto
            {
                Id = compra.IdCompra,
                Fecha = compra.Fecha,
                Proveedor = compra.Proveedor?.Nombre,
                tipoPago = compra.TipoPago,
                total = compra.Total
            } ).ToList();

            return compras;
        }
    }
}
