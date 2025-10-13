using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Producto
{
    public long IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Unidad { get; set; }

    public string? Descripcion { get; set; }

    public decimal? PrecioBase { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
