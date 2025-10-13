using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class AplicacionTratamiento
{
    public long IdAplicacionTratamiento { get; set; }

    public long? AnimalId { get; set; }

    public long? TratamientoId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? DosisAplicada { get; set; }

    public long? VeterinarioId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Tratamiento? Tratamiento { get; set; }

    public virtual Empleado? Veterinario { get; set; }
}
