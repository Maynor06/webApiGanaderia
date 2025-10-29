using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class InventarioMedicamento
{
    public long IdInventarioMedicamento { get; set; }

    public long? MedicamentoId { get; set; }

    public decimal Cantidad { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public string? Lote { get; set; }

    public virtual Medicamento? Medicamento { get; set; }
}
