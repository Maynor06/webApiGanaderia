using WebapiProyect.DTO;
using WebapiProyect.Models;

namespace WebapiProyect.Interfaces
{
    public interface Isuplementos
    {
        public Task<List<SuplementosDto>> GetSuplementosAsync();

    }
}
