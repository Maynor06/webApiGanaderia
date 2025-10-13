using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Montum
{
    public long IdMonta { get; set; }

    public long? MachoId { get; set; }

    public long? HembraId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Tipo { get; set; }

    public virtual Animal? Hembra { get; set; }

    public virtual Animal? Macho { get; set; }
}
