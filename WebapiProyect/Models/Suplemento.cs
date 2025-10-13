using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Suplemento
{
    public long IdSuplemento { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Nutrientes { get; set; }

    public virtual ICollection<InventarioSuplemento> InventarioSuplementos { get; set; } = new List<InventarioSuplemento>();
}
