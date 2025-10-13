using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ReporteProduccion
{
    public long IdReporteProduccion { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Tipo { get; set; }

    public long? EmpleadoId { get; set; }

    public string? DatosResumen { get; set; }

    public string? ArchivoUrl { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
