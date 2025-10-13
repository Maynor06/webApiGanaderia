using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Herramientum
{
    public long IdHerramienta { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaAdquisicion { get; set; }

    public virtual ICollection<InventarioHerramientum> InventarioHerramienta { get; set; } = new List<InventarioHerramientum>();
}
