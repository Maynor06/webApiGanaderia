namespace WebapiProyect.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> probarConexion();

        Task<string> procesarDataAsync(string prompt);

    }
}
