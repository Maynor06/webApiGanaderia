using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface IProduccion
    {
        Task<ProduccionDto> GetProduccionMesLater();
    }
}
