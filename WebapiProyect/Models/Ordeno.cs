using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Ordeno
{
    public long IdOrdeno { get; set; }

    public long? AnimalId { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Litros { get; set; }

    public string? Turno { get; set; }

    public long? OrdenadorId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Empleado? Ordenador { get; set; }
}
