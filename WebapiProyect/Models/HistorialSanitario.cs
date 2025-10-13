using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class HistorialSanitario
{
    public long IdHistorial { get; set; }

    public long? AnimalId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Diagnostico { get; set; }

    public string? Observaciones { get; set; }

    public virtual Animal? Animal { get; set; }
}
