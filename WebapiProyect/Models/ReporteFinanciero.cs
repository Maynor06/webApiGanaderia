using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ReporteFinanciero
{
    public long IdReporteFinanciero { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Ingresos { get; set; }

    public decimal? Egresos { get; set; }

    public decimal? Balance { get; set; }

    public long? EmpleadoId { get; set; }

    public string? ArchivoUrl { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
