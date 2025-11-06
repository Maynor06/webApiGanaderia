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
                .Include(c => c.Proveedor).Include(c => c.DetalleCompras).ToListAsync();

            var compras = results.Select(compra => new ComprasDto
            {
                Id = compra.IdCompra,
                Fecha = compra.Fecha,
                Proveedor = compra.Proveedor?.Nombre,
                tipoPago = compra.TipoPago,
                total = compra.Total,
                ProveedorId = compra.ProveedorId ?? 0,
                DetalleCompras = compra.DetalleCompras.Select(detalle => new DetalleCompraRequestDto
                {
                    DetalleCompraId = detalle.IdDetalleCompra,
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario
                } ).ToList()
            } ).ToList();

            return compras;
        }
        public async Task<ComprasDto> CreateCompra(compraRequestDto compraDto)
        {
            decimal totalCompra = 0;
            var detallesCompra = new List<DetalleCompra>();

            foreach (var detalle in compraDto.DetalleCompras)
            {
                decimal subtotal = detalle.Cantidad * detalle.PrecioUnitario;
                totalCompra += subtotal;

                var detalleCompra = new DetalleCompra
                {
                    ProductoId = detalle.ProductoId,
                    Cantidad = detalle.Cantidad,
                    PrecioUnitario = detalle.PrecioUnitario
                };
                detallesCompra.Add(detalleCompra);
            }

            var compra = new Compra
            {
                Fecha = compraDto.Fecha,
                ProveedorId = compraDto.ProveedorId,
                TipoPago = compraDto.TipoPago,
                Total = totalCompra,
                DetalleCompras = detallesCompra
            };

            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return new ComprasDto
            {
                Id = compra.IdCompra,
                Fecha = compra.Fecha,
                Proveedor = compra.Proveedor?.Nombre,
                tipoPago = compra.TipoPago,
                total = compra.Total
            };

        }



        public async Task<ComprasDto> UpdateCmpra(compraRequestDto compraDto, long id)
        {
            var compraExistente = await _context.Compras
                .Include(c => c.Proveedor)
                .FirstOrDefaultAsync(c => c.IdCompra == id);

            if (compraExistente == null)
            {
                throw new Exception($"La compra con ID {id} no existe.");
            }

            compraExistente.ProveedorId = compraDto.ProveedorId;
            compraExistente.Fecha = compraDto.Fecha;
            compraExistente.TipoPago = compraDto.TipoPago;

            
            decimal totalCalculado = 0;
            var existingDetails = compraExistente.DetalleCompras.ToList();
            var incomingDetails = compraDto.DetalleCompras;

            var incomingDetailIds = incomingDetails
                .Where(d => d.DetalleCompraId> 0)
                .Select(d => d.DetalleCompraId)
                .ToHashSet();

            var detailsToDelete = existingDetails
                .Where(ed => !incomingDetailIds.Contains(ed.IdDetalleCompra))
                .ToList();

            _context.DetalleCompras.RemoveRange(detailsToDelete);


            foreach (var detalleDto in incomingDetails)
            {
                decimal cantidad = detalleDto.Cantidad;
                decimal precio = detalleDto.PrecioUnitario;
                decimal subtotal = cantidad * precio;
                totalCalculado += subtotal;

                if (detalleDto.DetalleCompraId > 0)
                {
                    var detalleExistente = existingDetails
                        .FirstOrDefault(ed => ed.IdDetalleCompra == detalleDto.DetalleCompraId);

                    if (detalleExistente != null)
                    {
                        detalleExistente.ProductoId = detalleDto.ProductoId;
                        detalleExistente.Cantidad = cantidad;
                        detalleExistente.PrecioUnitario = precio;
                    }
                }
                else
                {
                    var nuevoDetalle = new DetalleCompra
                    {
                        ProductoId = detalleDto.ProductoId,
                        Cantidad = cantidad,
                        PrecioUnitario = precio,
                    };
                    compraExistente.DetalleCompras.Add(nuevoDetalle);
                }
            }

            compraExistente.Total = totalCalculado; // Asignar el total calculado

            await _context.SaveChangesAsync();

            return new ComprasDto
            {
                Id = compraExistente.IdCompra,
                Fecha = compraExistente.Fecha,
                Proveedor = compraExistente.Proveedor?.Nombre,
                tipoPago = compraExistente.TipoPago,
                total = compraExistente.Total
            };
        }

        public Task<bool> DeleteCompra(long id)
        {
            var compra = _context.Compras.Find(id);
            var detallesCompras = _context.DetalleCompras.Where(dc => dc.CompraId == id).ToList();
            if (compra == null) return Task.FromResult(false);
            _context.DetalleCompras.RemoveRange(detallesCompras);
            _context.Compras.Remove(compra);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }

}
