using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface IProveedor
    {
        Task<List<ProveedorDto>> GetProveedores();
    }
}
