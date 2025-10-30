using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class VentaService: IVentas
    {
        private readonly ApplicationDbContext _context;
        public VentaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ventum> ActualizarVenta(long id, Ventum venta)
        {
            try
            {
                var existingVenta = _context.Venta.Find(id);
                if (existingVenta == null)
                {
                    throw new KeyNotFoundException("Venta no encontrada");
                }
                existingVenta.Total = venta.Total;
                existingVenta.Fecha = venta.Fecha;
                existingVenta.TipoPago = venta.TipoPago;
                existingVenta.ClienteId = venta.ClienteId;
                _context.Venta.Update(existingVenta);
                await _context.SaveChangesAsync();
                return existingVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la venta", ex);
            }

        }

        public Task<Ventum> CreateVenta(Ventum venta)
        {
            try
            {
                _context.Venta.Add(venta);
                _context.SaveChanges();
                return Task.FromResult(venta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la venta", ex);
            }

        }

        public async Task<List<VentasDto>> GetVentas()
        {
            try
            {
                var results = await _context.Venta
                    .Include(v => v.Cliente).ToListAsync();

                var ventasDto = results.Select(v => new VentasDto
                {
                    Fecha = v.Fecha,
                    IdVenta = v.IdVenta,
                    NombreCliente = v.Cliente.Nombre,
                    TipoPago = v.TipoPago,
                    Total = v.Total
                }).ToList();

                return ventasDto;
            }catch (Exception e)
            {
                throw new Exception("No se pudo extraer de manera correcta", e);
            }

        }
    }
}
