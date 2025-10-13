using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class InventarioSuplemento
{
    public long IdInventarioSuplemento { get; set; }

    public long? SuplementoId { get; set; }

    public decimal? Cantidad { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? Lote { get; set; }

    public virtual Suplemento? Suplemento { get; set; }
}
