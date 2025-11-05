using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;
using WebapiProyect.Services;

namespace WebapiProyect.Controllers
{
    [Route("api/Archivo")]
    [ApiController]
    public class Exportar : ControllerBase
    {
        private readonly GeneradorArchivos _generador;

        public Exportar(GeneradorArchivos generador)
        {
            _generador = generador;
        }


        [HttpGet("{entidad}")]
        public async Task<IActionResult> ExportarDatos(string entidad, [FromQuery] string formato)
        {

            MemoryStream stream;
            string contentType;
            string extension;

            switch (formato.ToLower())
            {
                case "excel":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    extension = "xlsx";
                    break;
                case "pdf":
                    contentType = "application/pdf";
                    extension = "pdf";
                    // Nota: Aquí _generador.Crear(..., "pdf") deberá tener la lógica de PDF.
                    break;
                default:
                    return BadRequest(new { message = "Formato de exportación no válido. Use 'excel' o 'pdf'." });
            }


            try
            {
                var datosGenericos = await _generador.Obtenerdatos(entidad);

                switch (entidad.ToLower())
                {
                    case "raza":
                        stream = _generador.Crear((List<Raza>)datosGenericos, formato);
                        break;
                    case "factura":
                        stream = _generador.Crear((List<Factura>)datosGenericos, formato);
                        break;
                    case "venta":
                        stream = _generador.Crear((List<Ventum>)datosGenericos, formato);
                        break;
                    case "animal":
                        stream = _generador.Crear((List<Animal>)datosGenericos, formato);
                        break;
                    case "empleado":
                        stream = _generador.Crear((List<Empleado>)datosGenericos, formato);
                        break;
                    case "planilla":
                        stream = _generador.Crear((List<Planilla>)datosGenericos, formato);
                        break;
                    case "potrero":
                        stream = _generador.Crear((List<Potrero>)datosGenericos, formato);
                        break;
                    case "establo":
                        stream = _generador.Crear((List<Establo>)datosGenericos, formato);
                        break;
                    case "alimento":
                        stream = _generador.Crear((List<ProductoAlimenticio>)datosGenericos, formato);
                        break;
                    case "suplemento":
                        stream = _generador.Crear((List<Suplemento>)datosGenericos, formato);
                        break;
                    case "medicamento":
                        stream = _generador.Crear((List<Medicamento>)datosGenericos, formato);
                        break;
                    case "herramieno":
                        stream = _generador.Crear((List<Herramientum>)datosGenericos, formato);
                        break;
                    case "maquinaria":
                        stream = _generador.Crear((List<Maquinarium>)datosGenericos, formato);
                        break;
                    case "compras":
                        stream = _generador.Crear((List<Compra>)datosGenericos, formato);
                        break;

                    default:
                        return BadRequest(new { message = $"Entidad '{entidad}' no reconocida para exportación." });
                }
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidCastException)
            {
                return StatusCode(500, new { message = "Error interno: El tipo de datos no coincide con la entidad solicitada." });
            }


            string nombreArchivo = $"{entidad}_{DateTime.Now:yyyyMMdd}.{extension}";

            return File(stream, contentType, nombreArchivo);
        }

    }
}
