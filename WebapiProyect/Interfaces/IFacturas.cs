using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IFacturas
    {
        Task<List<FacturaDto>> GetFacturas();
        Task<Factura> CreateFactura(Factura factura);
        Task<Factura> ActualizarFactura(long id, Factura factura);
    }
}
