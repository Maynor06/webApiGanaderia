using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Establo
{
    public long IdEstablo { get; set; }

    public string? Nombre { get; set; }

    public int Capacidad { get; set; }

    public long? EmpleadoId { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
