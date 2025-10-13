using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class InventarioHerramientum
{
    public long IdInventarioHerramienta { get; set; }

    public long? HerramientaId { get; set; }

    public decimal? Cantidad { get; set; }

    public string? Estado { get; set; }

    public virtual Herramientum? Herramienta { get; set; }
}
