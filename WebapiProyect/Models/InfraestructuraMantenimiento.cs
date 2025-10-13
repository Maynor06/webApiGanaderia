using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class InfraestructuraMantenimiento
{
    public long IdInfraMant { get; set; }

    public string? InfraestructuraTipo { get; set; }

    public long? InfraestructuraId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public long? EmpleadoId { get; set; }
}
