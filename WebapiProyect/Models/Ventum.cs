using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Ventum
{
    public long IdVenta { get; set; }

    public long? ClienteId { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string? TipoPago { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
