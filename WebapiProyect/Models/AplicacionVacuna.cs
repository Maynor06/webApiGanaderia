using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class AplicacionVacuna
{
    public long IdAplicacionVacuna { get; set; }

    public long? AnimalId { get; set; }

    public long? VacunaId { get; set; }

    public DateOnly? Fecha { get; set; } 

    public string? DosisAplicada { get; set; }

    public long? EmpleadoId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Vacuna? Vacuna { get; set; }
}
