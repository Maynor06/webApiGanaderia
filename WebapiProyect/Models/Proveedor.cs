using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Proveedor
{
    public long IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Contacto { get; set; }

    public string? Direccion { get; set; }

    public string? TipoProveedor { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<ProductoAlimenticio> ProductoAlimenticios { get; set; } = new List<ProductoAlimenticio>();
}
