using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ParticipacionCapacitacion
{
    public long IdParticipacion { get; set; }

    public long? EmpleadoId { get; set; }

    public long? CapacitacionId { get; set; }

    public string? Resultado { get; set; }

    public virtual Capacitacion? Capacitacion { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
