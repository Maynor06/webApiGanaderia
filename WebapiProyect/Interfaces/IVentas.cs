using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IVentas
    {
        Task<List<VentasDto>> GetVentas();
        Task<Ventum> CreateVenta(Ventum venta);
        Task<Ventum> ActualizarVenta(long id, Ventum venta);

    }
}
