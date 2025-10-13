using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Tratamiento
{
    public long IdTratamiento { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AplicacionTratamiento> AplicacionTratamientos { get; set; } = new List<AplicacionTratamiento>();
}
