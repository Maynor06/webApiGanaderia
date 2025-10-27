using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ProduccionCarne
{
    public long IdProduccionCarne { get; set; }

    public long? AnimalId { get; set; }

    public decimal PesoCanal { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Destino { get; set; }

    public virtual Animal? Animal { get; set; }
}
