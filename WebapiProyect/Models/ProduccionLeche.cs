using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ProduccionLeche
{
    public long IdProduccionLeche { get; set; }

    public long? AnimalId { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal Litros { get; set; }

    public long? EmpleadoId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
