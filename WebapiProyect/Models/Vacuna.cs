using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Vacuna
{
    public long IdVacuna { get; set; }

    public string? Nombre { get; set; }

    public string? Dosis { get; set; }

    public int? IntervaloDias { get; set; }

    public string? Fabricante { get; set; }

    public virtual ICollection<AplicacionVacuna> AplicacionVacunas { get; set; } = new List<AplicacionVacuna>();
}
