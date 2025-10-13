using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Gestacion
{
    public long IdGestacion { get; set; }

    public long? HembraId { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaEstimadaParto { get; set; }

    public string? Estado { get; set; }

    public virtual Animal? Hembra { get; set; }
}
