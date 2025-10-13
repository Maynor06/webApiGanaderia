using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Corral
{
    public long IdCorral { get; set; }

    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    public string? Estado { get; set; }
}
