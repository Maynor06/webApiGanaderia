namespace WebapiProyect.Interfaces
{
    public interface IDataAccessService
    {
        Task<string> ExecuteSqlGetJsonAsync(string sqlQuery);
    }
}
