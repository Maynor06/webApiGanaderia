using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class FacturaService: IFacturas
    {
        private readonly ApplicationDbContext _context;
        public FacturaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Factura> ActualizarFactura(long id, Factura factura)
        {
            try
            {
                var existingFactura = _context.Facturas.Find(id);
                if (existingFactura == null)
                {
                    throw new KeyNotFoundException("Factura no encontrada");
                }
                existingFactura.Numero = factura.Numero;
                existingFactura.Fecha = factura.Fecha;
                existingFactura.ClienteId = factura.ClienteId;
                existingFactura.ArchivoUrl = factura.ArchivoUrl;
                existingFactura.MontoTotal = factura.MontoTotal;
                existingFactura.ProveedorId = factura.ProveedorId;
                _context.Facturas.Update(existingFactura);
                await _context.SaveChangesAsync();
                return existingFactura;
            }catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura", ex);
            }

        }

        public async Task<Factura> CreateFactura(Factura factura)
        {

            try
            {
                var result = await _context.Facturas.AddAsync(factura);
                await  _context.SaveChangesAsync();
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la factura", ex);
            }
        }

        public async Task<List<FacturaDto>> GetFacturas()
        {

            try
            {
                var results = await _context.Facturas.Include(f => f.Cliente)
                    .Include(f => f.Proveedor).Include(f => f.Pagos).ToListAsync();

                var facturasDto = results.Select(f => new FacturaDto
                {
                    IdFactura = f.IdFactura,
                    Numero = f.Numero,
                    Fecha = f.Fecha,
                    MontoTotal = f.MontoTotal,
                    MontoPagado = f.Pagos.Sum(p => p.Monto),
                    Origen = f.ClienteId != null ? "Cliente" : (f.ProveedorId != null ? "Proveedor" : "N/A"),
                    ProveedorId = f.ProveedorId,
                }).ToList();

                return facturasDto;
            }catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas", ex);

            }

        }
    }
}
