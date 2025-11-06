using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class DetalleCompra
{
    public long IdDetalleCompra { get; set; }

    public long CompraId { get; set; }

    public long ProductoId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Compra? Compra { get; set; }

    public virtual Producto? Producto { get; set; }
}
