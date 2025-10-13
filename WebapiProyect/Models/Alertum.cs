using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Alertum
{
    public long IdAlerta { get; set; }

    public string? Tipo { get; set; }

    public DateTime? FechaGenerada { get; set; }

    public string? Estado { get; set; }

    public string? Detalle { get; set; }

    public string? EntidadOrigen { get; set; }

    public long? IdOrigen { get; set; }
}
