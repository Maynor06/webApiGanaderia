using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface ICompra
    {
        Task<List<ComprasDto>> GetComprasAsync();
    }
}
