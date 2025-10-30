using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface IMaquinaria
    {
        Task<List<Maquinarium>> GetMaquinarias();
        Task<Maquinarium> CreateMaquinaria(Maquinarium maquinaria);
        Task<Maquinarium> ActualizarMaquinaria(long id, Maquinarium maquinaria);
    }
}
