using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Potrero
{
    public long IdPotrero { get; set; }

    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    public decimal? Hectareas { get; set; }

    public string? Estado { get; set; }
}
