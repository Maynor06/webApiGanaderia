using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface IProducto
    {
        Task<List<ProductoDto>> GetProductos();
    }
}
