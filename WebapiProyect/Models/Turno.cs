using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Turno
{
    public long IdTurno { get; set; }

    public long? EmpleadoId { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
