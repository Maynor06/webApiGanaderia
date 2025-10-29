using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class MedicamentoService : IMedicamento
    {
        private readonly ApplicationDbContext _context;

        public MedicamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Medicamento> ActualizarMedicamento(long id, Medicamento medicamento)
        {
            try
            {
                Medicamento medicamentofound = await _context.Medicamentos.FindAsync(id);
                if (medicamentofound == null)
                {
                    throw new Exception("Medicamento no encontrado");
                }
                medicamentofound.Nombre = medicamento.Nombre;
                medicamentofound.Laboratorio = medicamento.Laboratorio;
                medicamentofound.DosisRecomendada = medicamento.DosisRecomendada;
                _context.Medicamentos.Update(medicamentofound);
                await _context.SaveChangesAsync();
                return medicamentofound;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el medicamento: " + ex.Message);
            }
        }

        public async Task<Medicamento> CreateMedicamentoAsync(Medicamento medicamento)
        {
            try
            {
                await _context.Medicamentos.AddAsync(medicamento);
                await _context.SaveChangesAsync();
                return medicamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el medicamento: " + ex.Message);
            }
        }

        public async Task<List<MedicamentosDto>> getMedicamentosConCantidadYFechaVencimiento()
        {
            var results = await _context.Medicamentos.Include(m => m.InventarioMedicamentos).ToListAsync();
            var medicamentosDto = results.Select(m => new MedicamentosDto
            {
                IdMedicamento = m.IdMedicamento,
                Nombre = m.Nombre,
                Laboratorio = m.Laboratorio,
                DosisRecomendada = m.DosisRecomendada,
                cantidadDisponible = m.InventarioMedicamentos.Sum(im => im.Cantidad),
                fechaVencimiento = m.InventarioMedicamentos.Min(im => im.FechaVencimiento).ToString("yyyy-MM-dd")
            }).ToList();
            return medicamentosDto;
        }
    }
}
