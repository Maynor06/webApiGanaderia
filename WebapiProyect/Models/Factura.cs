using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Factura
{
    public long IdFactura { get; set; }

    public string? Numero { get; set; }

    public DateOnly? Fecha { get; set; }

    public long? ClienteId { get; set; }

    public long? ProveedorId { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? ArchivoUrl { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Proveedor? Proveedor { get; set; }
}
