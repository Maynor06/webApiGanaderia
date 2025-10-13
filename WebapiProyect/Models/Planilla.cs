using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Planilla
{
    public long IdPlanilla { get; set; }

    public byte? Mes { get; set; }

    public short? Anio { get; set; }

    public long? EmpleadoId { get; set; }

    public decimal? Sueldo { get; set; }

    public decimal? HorasExtra { get; set; }

    public decimal? Deducciones { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
