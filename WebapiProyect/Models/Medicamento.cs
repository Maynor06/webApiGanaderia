using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Medicamento
{
    public long IdMedicamento { get; set; }

    public string? Nombre { get; set; }

    public string? Laboratorio { get; set; }

    public string? DosisRecomendada { get; set; }

    public virtual ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; } = new List<InventarioMedicamento>();
}
