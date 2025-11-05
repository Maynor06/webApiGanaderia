using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class GeneradorArchivos
    {
        private readonly ApplicationDbContext _context; 

        public GeneradorArchivos(ApplicationDbContext context)
        {
            _context = context;
        }

        public MemoryStream Crear<T>(List<T> listaDatos, string tipoArchivo)
        {
            if (tipoArchivo.ToLower() == "excel")
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Datos");

                worksheet.Cell(1, 1).InsertTable(listaDatos);

                worksheet.ColumnsUsed().AdjustToContents();

                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);
                return stream;

            }

            throw new NotSupportedException("Format no implementado");

        }

        public async Task<Object> Obtenerdatos(string entidad)
        {
            switch (entidad.ToLower())
            {
                case "raza":
                    return await _context.Razas.ToListAsync();
                case "factura":
                    return await _context.Facturas.ToListAsync();
                case "venta":
                    return await _context.Venta.ToListAsync();
                case "animal":
                    return await _context.Animals.ToListAsync();
                case "empleado":
                    return await _context.Empleados.ToListAsync();
                case "planilla":
                    return await _context.Planillas.ToListAsync();
                case "potrero":
                    return await _context.Potreros.ToListAsync();
                case "establo":
                    return await _context.Establos.ToListAsync(); 
                case "alimento":
                    return await _context.ProductoAlimenticios.ToListAsync();
                case "suplemento": 
                    return await _context.Suplementos.ToListAsync();
                case "medicamento":
                    return await _context.Medicamentos.ToListAsync();
                case "herramienta":
                    return await _context.Herramienta.ToListAsync(); 
                case "maquinaria":
                    return await _context.Maquinaria.ToListAsync();
                case "Compras": 
                    return await _context.Compras.ToListAsync();
                
                default:
                    throw new NotSupportedException("Entidad no soportada");
            }
        }


    }
}
