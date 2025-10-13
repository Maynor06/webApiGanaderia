using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Maquinarium
{
    public long IdMaquinaria { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaAdquisicion { get; set; }
}
