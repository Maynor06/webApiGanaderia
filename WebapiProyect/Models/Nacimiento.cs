using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Nacimiento
{
    public long IdNacimiento { get; set; }

    public long? MadreId { get; set; }

    public DateOnly? Fecha { get; set; }

    public long? CriaAnimalId { get; set; }

    public string? Sexo { get; set; }

    public decimal? Peso { get; set; }

    public virtual Animal? CriaAnimal { get; set; }

    public virtual Animal? Madre { get; set; }
}
