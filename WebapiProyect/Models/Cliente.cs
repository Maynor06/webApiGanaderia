using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Cliente
{
    public long IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Contacto { get; set; }

    public string? Direccion { get; set; }

    public string? TipoCliente { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
