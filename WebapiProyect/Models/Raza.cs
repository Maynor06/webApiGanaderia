using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Raza
{
    public long IdRaza { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public long? EspecieId { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual Especie? Especie { get; set; }
}
