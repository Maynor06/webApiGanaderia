using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Empleado
{
    public long IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public long? CargoId { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public decimal? SalarioBase { get; set; }

    public string? FotoUrl { get; set; }

    public virtual ICollection<AplicacionTratamiento> AplicacionTratamientos { get; set; } = new List<AplicacionTratamiento>();

    public virtual ICollection<AplicacionVacuna> AplicacionVacunas { get; set; } = new List<AplicacionVacuna>();

    public virtual ICollection<Capacitacion> Capacitacions { get; set; } = new List<Capacitacion>();

    public virtual Cargo? Cargo { get; set; }

    public virtual ICollection<Desparasitacion> Desparasitacions { get; set; } = new List<Desparasitacion>();

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<Establo> Establos { get; set; } = new List<Establo>();

    public virtual ICollection<Mortalidad> Mortalidads { get; set; } = new List<Mortalidad>();

    public virtual ICollection<Ordeno> Ordenos { get; set; } = new List<Ordeno>();

    public virtual ICollection<ParticipacionCapacitacion> ParticipacionCapacitacions { get; set; } = new List<ParticipacionCapacitacion>();

    public virtual ICollection<Planilla> Planillas { get; set; } = new List<Planilla>();

    public virtual ICollection<ProduccionLeche> ProduccionLeches { get; set; } = new List<ProduccionLeche>();

    public virtual ICollection<ReporteFinanciero> ReporteFinancieros { get; set; } = new List<ReporteFinanciero>();

    public virtual ICollection<ReporteProduccion> ReporteProduccions { get; set; } = new List<ReporteProduccion>();

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
