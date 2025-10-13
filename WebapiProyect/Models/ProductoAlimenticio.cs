using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class ProductoAlimenticio
{
    public long IdProductoAlimenticio { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public long? ProveedorId { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual ICollection<ConsumoAnimal> ConsumoAnimals { get; set; } = new List<ConsumoAnimal>();

    public virtual ICollection<InventarioAlimento> InventarioAlimentos { get; set; } = new List<InventarioAlimento>();

    public virtual Proveedor? Proveedor { get; set; }
}
