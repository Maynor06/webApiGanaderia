using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Interfaces;

namespace WebapiProyect.Controllers
{
    [Route("api/Dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboard _dashboardService;

        public DashboardController(IDashboard dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            var dashboardData = await _dashboardService.GetDashboardData();
            return Ok(dashboardData);
        }

    }
}
