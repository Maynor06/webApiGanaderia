using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Pago
{
    public long IdPago { get; set; }

    public long? FacturaId { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Monto { get; set; }

    public string? TipoPago { get; set; }

    public virtual Factura? Factura { get; set; }
}
