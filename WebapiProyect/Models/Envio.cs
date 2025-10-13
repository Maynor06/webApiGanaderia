using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Envio
{
    public long IdEnvio { get; set; }

    public long? VentaId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Destino { get; set; }

    public long? TransporteId { get; set; }

    public long? EmpleadoId { get; set; }

    public string? Detalle { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Transporte? Transporte { get; set; }

    public virtual Ventum? Venta { get; set; }
}
