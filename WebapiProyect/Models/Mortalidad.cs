using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Mortalidad
{
    public long IdMortalidad { get; set; }

    public long? AnimalId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Causa { get; set; }

    public long? EmpleadoId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
