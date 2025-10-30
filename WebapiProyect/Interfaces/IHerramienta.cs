using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IHerramienta
    {

        Task<List<HerramientaDto>> GetHerramientasConCantidadDisponible();
        Task<Herramientum> CreateHerramienta(Herramientum herramienta);
        Task<Herramientum> ActualizarHerramienta(long id, Herramientum herramienta);
    }
}
