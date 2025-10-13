using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Especie
{
    public long IdEspecie { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
