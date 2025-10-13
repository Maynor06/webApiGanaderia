using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Capacitacion
{
    public long IdCapacitacion { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha { get; set; }

    public long? EmpleadoId { get; set; }

    public string? Tema { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<ParticipacionCapacitacion> ParticipacionCapacitacions { get; set; } = new List<ParticipacionCapacitacion>();
}
