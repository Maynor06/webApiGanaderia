using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Desparasitacion
{
    public long IdDesparasitacion { get; set; }

    public long? AnimalId { get; set; }

    public string? Producto { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? DosisAplicada { get; set; }

    public long? EmpleadoId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
