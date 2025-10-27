using WebapiProyect.DTO;

namespace WebapiProyect.Interfaces
{
    public interface IDashboard
    {
        Task<DashboardDTO> GetDashboardData();

    }
}
