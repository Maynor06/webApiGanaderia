using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class RegistroParto
{
    public long IdRegistroParto { get; set; }

    public long? MadreId { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? NumeroCrias { get; set; }

    public string? Observaciones { get; set; }

    public virtual Animal? Madre { get; set; }
}
