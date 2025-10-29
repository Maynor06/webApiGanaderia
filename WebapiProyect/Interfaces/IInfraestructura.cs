using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface IInfraestructura
    {
        Task<InfraestructuraDto> getRegistros();
    }
}
