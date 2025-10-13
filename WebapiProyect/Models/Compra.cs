using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Compra
{
    public long IdCompra { get; set; }

    public long? ProveedorId { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string? TipoPago { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor? Proveedor { get; set; }
}
