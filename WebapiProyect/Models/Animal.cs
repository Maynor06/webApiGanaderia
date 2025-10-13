using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Animal
{
    public long IdAnimal { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public long? EspecieId { get; set; }

    public long? RazaId { get; set; }

    public string? Sexo { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public decimal? Peso { get; set; }

    public string? Estado { get; set; }

    public string? FotoUrl { get; set; }

    public virtual ICollection<AplicacionTratamiento> AplicacionTratamientos { get; set; } = new List<AplicacionTratamiento>();

    public virtual ICollection<AplicacionVacuna> AplicacionVacunas { get; set; } = new List<AplicacionVacuna>();

    public virtual ICollection<ConsumoAnimal> ConsumoAnimals { get; set; } = new List<ConsumoAnimal>();

    public virtual ICollection<Desparasitacion> Desparasitacions { get; set; } = new List<Desparasitacion>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Especie? Especie { get; set; }

    public virtual ICollection<Gestacion> Gestacions { get; set; } = new List<Gestacion>();

    public virtual ICollection<HistorialSanitario> HistorialSanitarios { get; set; } = new List<HistorialSanitario>();

    public virtual ICollection<Montum> MontumHembras { get; set; } = new List<Montum>();

    public virtual ICollection<Montum> MontumMachos { get; set; } = new List<Montum>();

    public virtual ICollection<Mortalidad> Mortalidads { get; set; } = new List<Mortalidad>();

    public virtual ICollection<Nacimiento> NacimientoCriaAnimals { get; set; } = new List<Nacimiento>();

    public virtual ICollection<Nacimiento> NacimientoMadres { get; set; } = new List<Nacimiento>();

    public virtual ICollection<Ordeno> Ordenos { get; set; } = new List<Ordeno>();

    public virtual ICollection<ProduccionCarne> ProduccionCarnes { get; set; } = new List<ProduccionCarne>();

    public virtual ICollection<ProduccionLeche> ProduccionLeches { get; set; } = new List<ProduccionLeche>();

    public virtual Raza? Raza { get; set; }

    public virtual ICollection<RegistroParto> RegistroPartos { get; set; } = new List<RegistroParto>();
}
