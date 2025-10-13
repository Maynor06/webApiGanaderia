using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ConsumoAnimal
{
    public long IdConsumoAnimal { get; set; }

    public long? AnimalId { get; set; }

    public long? ProductoAlimenticioId { get; set; }

    public decimal? Cantidad { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual ProductoAlimenticio? ProductoAlimenticio { get; set; }
}
