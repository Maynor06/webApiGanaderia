using Microsoft.EntityFrameworkCore;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class MaquinariaService: IMaquinaria
    {
        private readonly ApplicationDbContext _context;

        public MaquinariaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Maquinarium> ActualizarMaquinaria(long id, Maquinarium maquinaria)
        {
            try
            {
                var existingMaquinaria = _context.Maquinaria.Find(id);
                if (existingMaquinaria == null)
                {
                    throw new KeyNotFoundException("Maquinaria no encontrada");
                }
                existingMaquinaria.Nombre = maquinaria.Nombre;
                existingMaquinaria.Tipo = maquinaria.Tipo;
                existingMaquinaria.Estado = maquinaria.Estado;
                existingMaquinaria.FechaAdquisicion = maquinaria.FechaAdquisicion;
                _context.Maquinaria.Update(existingMaquinaria);
                await _context.SaveChangesAsync();
                return existingMaquinaria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la maquinaria", ex);
            }
        }

        public async Task<Maquinarium> CreateMaquinaria(Maquinarium maquinaria)
        {
            try
            {
                _context.Maquinaria.Add(maquinaria);
                await _context.SaveChangesAsync();
                return maquinaria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la maquinaria", ex);
            }
        }

        public async Task<List<Maquinarium>> GetMaquinarias()
        {
            try
            {
                var maquinarias = await _context.Maquinaria.ToListAsync();
                return maquinarias;
            } catch (Exception ex) {
                throw new Exception("Error al obtener las maquinarias", ex);
             }

        }


    }
}
