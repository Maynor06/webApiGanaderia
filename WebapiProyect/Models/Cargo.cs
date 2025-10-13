using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Cargo
{
    public long IdCargo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
