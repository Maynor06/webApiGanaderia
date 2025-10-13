using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class InventarioAlimento
{
    public long IdInventarioAlimento { get; set; }

    public long? ProductoAlimenticioId { get; set; }

    public decimal? Cantidad { get; set; }

    public DateOnly? FechaEntrada { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? Lote { get; set; }

    public virtual ProductoAlimenticio? ProductoAlimenticio { get; set; }
}
