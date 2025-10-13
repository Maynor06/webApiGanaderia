using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Transporte
{
    public long IdTransporte { get; set; }

    public string? Vehiculo { get; set; }

    public string? Tipo { get; set; }

    public decimal? Capacidad { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
