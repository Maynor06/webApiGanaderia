using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class DashboardService: IDashboard
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<DashboardDTO> GetDashboardData()
        {
            int animalesActivos = _context.Animals.Count(a => a.Estado == "Activo");
            DateOnly fechaLimite = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
            DateTime fechaSemana = DateTime.Now.AddDays(-7);
            int vacunasAplicadas = _context.AplicacionVacunas.Count(v => v.Fecha != null && v.Fecha >= fechaLimite);
            int produccionLeche = _context.ProduccionLeches.Where(p => p.Fecha != null && p.Fecha >= fechaLimite)
                .Sum(p => (int?)p.Litros) ?? 0;
            
            int comprasMensuales = _context.Compras.Where(c => c.Fecha != null && c.Fecha >= fechaLimite)
                .Sum(c => (int?)c.Total) ?? 0;

            int ventasMensuales = _context.Venta.Where(v => v.Fecha != null && v.Fecha >= fechaLimite)
                .Sum(v => (int?)v.Total) ?? 0;

            int alertasSanitarias  = _context.Alerta.Count(a => a.FechaGenerada != null && a.FechaGenerada >= fechaSemana);

            DashboardDTO dashboard = new DashboardDTO
            {
                AnimalesActivos = animalesActivos,
                VacunasAplicadas = vacunasAplicadas,
                ProduccionLecheMensual = produccionLeche,
                IngresosMensuales = comprasMensuales,
                VentasMensuales = ventasMensuales,
                AlertasSanitarias = alertasSanitarias
            };
            
            return Task.FromResult(dashboard);

        }
    }
}
