using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class DetalleVentum
{
    public long IdDetalleVenta { get; set; }

    public long? VentaId { get; set; }

    public long? ProductoId { get; set; }

    public long? AnimalId { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Ventum? Venta { get; set; }
}
