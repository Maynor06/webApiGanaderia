using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface ICompra
    {
        Task<List<ComprasDto>> GetComprasAsync();
        Task<ComprasDto> CreateCompra(compraRequestDto compraDto);
        Task<ComprasDto> UpdateCmpra(compraRequestDto compraDto, long id);
        Task<Boolean> DeleteCompra(long id);
    }
}
