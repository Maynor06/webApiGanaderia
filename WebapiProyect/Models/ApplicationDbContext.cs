using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebapiProyect.DTO;

namespace WebapiProyect.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }

    public virtual DbSet<Alerta> Alerta { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AplicacionTratamiento> AplicacionTratamientos { get; set; }

    public virtual DbSet<AplicacionVacuna> AplicacionVacunas { get; set; }

    public virtual DbSet<Capacitacion> Capacitacions { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<ConsumoAnimal> ConsumoAnimals { get; set; }

    public virtual DbSet<Corral> Corrals { get; set; }

    public virtual DbSet<Desparasitacion> Desparasitacions { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Especie> Especies { get; set; }

    public virtual DbSet<Establo> Establos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Gestacion> Gestacions { get; set; }

    public virtual DbSet<Herramientum> Herramienta { get; set; }

    public virtual DbSet<HistorialSanitario> HistorialSanitarios { get; set; }

    public virtual DbSet<InfraestructuraMantenimiento> InfraestructuraMantenimientos { get; set; }

    public virtual DbSet<InventarioAlimento> InventarioAlimentos { get; set; }

    public virtual DbSet<InventarioHerramientum> InventarioHerramienta { get; set; }

    public virtual DbSet<InventarioMedicamento> InventarioMedicamentos { get; set; }

    public virtual DbSet<InventarioSuplemento> InventarioSuplementos { get; set; }

    public virtual DbSet<Maquinarium> Maquinaria { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Montum> Monta { get; set; }

    public virtual DbSet<Mortalidad> Mortalidads { get; set; }

    public virtual DbSet<Nacimiento> Nacimientos { get; set; }

    public virtual DbSet<Ordeno> Ordenos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<ParticipacionCapacitacion> ParticipacionCapacitacions { get; set; }

    public virtual DbSet<Planilla> Planillas { get; set; }

    public virtual DbSet<Potrero> Potreros { get; set; }

    public virtual DbSet<ProduccionCarne> ProduccionCarnes { get; set; }

    public virtual DbSet<ProduccionLeche> ProduccionLeches { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoAlimenticio> ProductoAlimenticios { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<RegistroParto> RegistroPartos { get; set; }

    public virtual DbSet<ReporteFinanciero> ReporteFinancieros { get; set; }

    public virtual DbSet<ReporteProduccion> ReporteProduccions { get; set; }

    public virtual DbSet<Suplemento> Suplementos { get; set; }

    public virtual DbSet<Transporte> Transportes { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vacuna> Vacunas { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    public virtual DbSet<AnimalDto> animalDto { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alerta>(entity =>
        {
            entity.HasKey(e => e.IdAlerta).HasName("PK__alerta__1227953E01E8D887");

            entity.ToTable("alerta");

            entity.Property(e => e.IdAlerta).HasColumnName("id_alerta");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.EntidadOrigen)
                .HasMaxLength(60)
                .HasColumnName("entidad_origen");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.FechaGenerada).HasColumnName("fecha_generada");
            entity.Property(e => e.IdOrigen).HasColumnName("id_origen");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.IdAnimal).HasName("PK__animal__1967CD2F4608D543");

            entity.ToTable("animal");

            entity.HasIndex(e => e.EspecieId, "IX_animal_especie");

            entity.HasIndex(e => e.RazaId, "IX_animal_raza");

            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.Codigo)
                .HasMaxLength(80)
                .HasColumnName("codigo");
            entity.Property(e => e.EspecieId).HasColumnName("especie_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(255)
                .HasColumnName("foto_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("peso");
            entity.Property(e => e.RazaId).HasColumnName("raza_id");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("sexo");

            entity.HasOne(d => d.Especie).WithMany(p => p.Animals)
                .HasForeignKey(d => d.EspecieId)
                .HasConstraintName("FK_animal_especie");

            entity.HasOne(d => d.Raza).WithMany(p => p.Animals)
                .HasForeignKey(d => d.RazaId)
                .HasConstraintName("FK_animal_raza");
        });

        modelBuilder.Entity<AplicacionTratamiento>(entity =>
        {
            entity.HasKey(e => e.IdAplicacionTratamiento).HasName("PK__aplicaci__B3C0AA0D35E9339B");

            entity.ToTable("aplicacion_tratamiento");

            entity.HasIndex(e => e.AnimalId, "IX_aptrat_animal");

            entity.HasIndex(e => e.TratamientoId, "IX_aptrat_trat");

            entity.HasIndex(e => e.VeterinarioId, "IX_aptrat_vet");

            entity.Property(e => e.IdAplicacionTratamiento).HasColumnName("id_aplicacion_tratamiento");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.DosisAplicada)
                .HasMaxLength(60)
                .HasColumnName("dosis_aplicada");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.TratamientoId).HasColumnName("tratamiento_id");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.AplicacionTratamientos)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_aptrat_animal");

            entity.HasOne(d => d.Tratamiento).WithMany(p => p.AplicacionTratamientos)
                .HasForeignKey(d => d.TratamientoId)
                .HasConstraintName("FK_aptrat_tratamiento");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.AplicacionTratamientos)
                .HasForeignKey(d => d.VeterinarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_aptrat_veterinario");
        });

        modelBuilder.Entity<AplicacionVacuna>(entity =>
        {
            entity.HasKey(e => e.IdAplicacionVacuna).HasName("PK__aplicaci__F462E0CE87755ADE");

            entity.ToTable("aplicacion_vacuna");

            entity.HasIndex(e => e.AnimalId, "IX_apvac_animal");

            entity.HasIndex(e => e.EmpleadoId, "IX_apvac_emp");

            entity.HasIndex(e => e.VacunaId, "IX_apvac_vacuna");

            entity.Property(e => e.IdAplicacionVacuna).HasColumnName("id_aplicacion_vacuna");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.DosisAplicada)
                .HasMaxLength(60)
                .HasColumnName("dosis_aplicada");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.VacunaId).HasColumnName("vacuna_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.AplicacionVacunas)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_apvac_animal");

            entity.HasOne(d => d.Empleado).WithMany(p => p.AplicacionVacunas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_apvac_empleado");

            entity.HasOne(d => d.Vacuna).WithMany(p => p.AplicacionVacunas)
                .HasForeignKey(d => d.VacunaId)
                .HasConstraintName("FK_apvac_vacuna");
        });

        modelBuilder.Entity<Capacitacion>(entity =>
        {
            entity.HasKey(e => e.IdCapacitacion).HasName("PK__capacita__FA471D9BAD2DDF75");

            entity.ToTable("capacitacion");

            entity.HasIndex(e => e.EmpleadoId, "IX_capacitacion_resp");

            entity.Property(e => e.IdCapacitacion).HasColumnName("id_capacitacion");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Tema)
                .HasMaxLength(255)
                .HasColumnName("tema");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Capacitacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_capacitacion_resp");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__cargo__D3C09EC5B7927694");

            entity.ToTable("cargo");

            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__cliente__677F38F5877864FC");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Contacto)
                .HasMaxLength(120)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(60)
                .HasColumnName("tipo_cliente");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__compra__C4BAA6044B803069");

            entity.ToTable("compra");

            entity.HasIndex(e => e.ProveedorId, "IX_compra_prov");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(60)
                .HasColumnName("tipo_pago");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_compra_proveedor");
        });

        modelBuilder.Entity<ConsumoAnimal>(entity =>
        {
            entity.HasKey(e => e.IdConsumoAnimal).HasName("PK__consumo___1BE555CF3BE511BB");

            entity.ToTable("consumo_animal");

            entity.HasIndex(e => e.AnimalId, "IX_consan_animal");

            entity.HasIndex(e => e.ProductoAlimenticioId, "IX_consan_prod");

            entity.Property(e => e.IdConsumoAnimal).HasColumnName("id_consumo_animal");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.ProductoAlimenticioId).HasColumnName("producto_alimenticio_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.ConsumoAnimals)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_consan_animal");

            entity.HasOne(d => d.ProductoAlimenticio).WithMany(p => p.ConsumoAnimals)
                .HasForeignKey(d => d.ProductoAlimenticioId)
                .HasConstraintName("FK_consan_prod");
        });

        modelBuilder.Entity<Corral>(entity =>
        {
            entity.HasKey(e => e.IdCorral).HasName("PK__corral__D5CA99354A80D787");

            entity.ToTable("corral");

            entity.Property(e => e.IdCorral).HasColumnName("id_corral");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Desparasitacion>(entity =>
        {
            entity.HasKey(e => e.IdDesparasitacion).HasName("PK__desparas__CD76C9EE3C66CA9B");

            entity.ToTable("desparasitacion");

            entity.HasIndex(e => e.AnimalId, "IX_despara_animal");

            entity.HasIndex(e => e.EmpleadoId, "IX_despara_emp");

            entity.Property(e => e.IdDesparasitacion).HasColumnName("id_desparasitacion");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.DosisAplicada)
                .HasMaxLength(60)
                .HasColumnName("dosis_aplicada");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Producto)
                .HasMaxLength(120)
                .HasColumnName("producto");

            entity.HasOne(d => d.Animal).WithMany(p => p.Desparasitacions)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_despara_animal");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Desparasitacions)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_despara_empleado");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__detalle___BD16E279F4A0AFA6");

            entity.ToTable("detalle_compra");

            entity.HasIndex(e => e.CompraId, "IX_detcomp_compra");

            entity.HasIndex(e => e.ProductoId, "IX_detcomp_prod");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("id_detalle_compra");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.CompraId).HasColumnName("compra_id");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CompraId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_detcomp_compra");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_detcomp_producto");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__detalle___5B265D473DB8EFD3");

            entity.ToTable("detalle_venta");

            entity.HasIndex(e => e.AnimalId, "IX_detventa_animal");

            entity.HasIndex(e => e.ProductoId, "IX_detventa_prod");

            entity.HasIndex(e => e.VentaId, "IX_detventa_venta");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("id_detalle_venta");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.VentaId).HasColumnName("venta_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_detventa_animal");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_detventa_producto");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_detventa_venta");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__88B51394F6747F83");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.CargoId, "IX_empleado_cargo");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(120)
                .HasColumnName("apellido");
            entity.Property(e => e.CargoId).HasColumnName("cargo_id");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(255)
                .HasColumnName("foto_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.SalarioBase)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("salario_base");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .HasConstraintName("FK_empleado_cargo");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.IdEnvio).HasName("PK__envio__8C48C8CA25E73020");

            entity.ToTable("envio");

            entity.HasIndex(e => e.EmpleadoId, "IX_envio_empleado");

            entity.HasIndex(e => e.TransporteId, "IX_envio_transporte");

            entity.HasIndex(e => e.VentaId, "IX_envio_venta");

            entity.Property(e => e.IdEnvio).HasColumnName("id_envio");
            entity.Property(e => e.Destino)
                .HasMaxLength(255)
                .HasColumnName("destino");
            entity.Property(e => e.Detalle)
                .HasMaxLength(500)
                .HasColumnName("detalle");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.TransporteId).HasColumnName("transporte_id");
            entity.Property(e => e.VentaId).HasColumnName("venta_id");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Envios)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_envio_empleado");

            entity.HasOne(d => d.Transporte).WithMany(p => p.Envios)
                .HasForeignKey(d => d.TransporteId)
                .HasConstraintName("FK_envio_transporte");

            entity.HasOne(d => d.Venta).WithMany(p => p.Envios)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK_envio_venta");
        });

        modelBuilder.Entity<Especie>(entity =>
        {
            entity.HasKey(e => e.IdEspecie).HasName("PK__especie__96DDB0B9EC0FE779");

            entity.ToTable("especie");

            entity.Property(e => e.IdEspecie).HasColumnName("id_especie");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Establo>(entity =>
        {
            entity.HasKey(e => e.IdEstablo).HasName("PK__establo__3F832F313E3F0FAE");

            entity.ToTable("establo");

            entity.HasIndex(e => e.EmpleadoId, "IX_establo_empleado");

            entity.Property(e => e.IdEstablo).HasColumnName("id_establo");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Establos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_establo_empleado");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__factura__6C08ED53FC199A5A");

            entity.ToTable("factura");

            entity.HasIndex(e => e.ClienteId, "IX_factura_cliente");

            entity.HasIndex(e => e.ProveedorId, "IX_factura_proveedor");

            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.ArchivoUrl)
                .HasMaxLength(255)
                .HasColumnName("archivo_url");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("monto_total");
            entity.Property(e => e.Numero)
                .HasMaxLength(60)
                .HasColumnName("numero");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_factura_cliente");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_factura_proveedor");
        });

        modelBuilder.Entity<Gestacion>(entity =>
        {
            entity.HasKey(e => e.IdGestacion).HasName("PK__gestacio__4563A7BB83FC9363");

            entity.ToTable("gestacion");

            entity.HasIndex(e => e.HembraId, "IX_gestacion_hembra");

            entity.Property(e => e.IdGestacion).HasColumnName("id_gestacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEstimadaParto).HasColumnName("fecha_estimada_parto");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.HembraId).HasColumnName("hembra_id");

            entity.HasOne(d => d.Hembra).WithMany(p => p.Gestacions)
                .HasForeignKey(d => d.HembraId)
                .HasConstraintName("FK_gestacion_hembra");
        });

        modelBuilder.Entity<Herramientum>(entity =>
        {
            entity.HasKey(e => e.IdHerramienta).HasName("PK__herramie__8772C7C2939B478B");

            entity.ToTable("herramienta");

            entity.Property(e => e.IdHerramienta).HasColumnName("id_herramienta");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAdquisicion).HasColumnName("fecha_adquisicion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<HistorialSanitario>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__historia__76E6C502F2B6B2E4");

            entity.ToTable("historial_sanitario");

            entity.HasIndex(e => e.AnimalId, "IX_historial_animal");

            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(255)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.Animal).WithMany(p => p.HistorialSanitarios)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_historial_animal");
        });

        modelBuilder.Entity<InfraestructuraMantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdInfraMant).HasName("PK__infraest__F62C036E771DBF04");

            entity.ToTable("infraestructura_mantenimiento");

            entity.Property(e => e.IdInfraMant).HasColumnName("id_infra_mant");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.InfraestructuraId).HasColumnName("infraestructura_id");
            entity.Property(e => e.InfraestructuraTipo)
                .HasMaxLength(60)
                .HasColumnName("infraestructura_tipo");
        });

        modelBuilder.Entity<InventarioAlimento>(entity =>
        {
            entity.HasKey(e => e.IdInventarioAlimento).HasName("PK__inventar__42FA41A59857984F");

            entity.ToTable("inventario_alimento");

            entity.HasIndex(e => e.ProductoAlimenticioId, "IX_invalim_prod");

            entity.Property(e => e.IdInventarioAlimento).HasColumnName("id_inventario_alimento");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.FechaEntrada).HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Lote)
                .HasMaxLength(60)
                .HasColumnName("lote");
            entity.Property(e => e.ProductoAlimenticioId).HasColumnName("producto_alimenticio_id");

            entity.HasOne(d => d.ProductoAlimenticio).WithMany(p => p.InventarioAlimentos)
                .HasForeignKey(d => d.ProductoAlimenticioId)
                .HasConstraintName("FK_inv_alim_prod");
        });

        modelBuilder.Entity<InventarioHerramientum>(entity =>
        {
            entity.HasKey(e => e.IdInventarioHerramienta).HasName("PK__inventar__6FF126FF078A0CC0");

            entity.ToTable("inventario_herramienta");

            entity.HasIndex(e => e.HerramientaId, "IX_invherr_herr");

            entity.Property(e => e.IdInventarioHerramienta).HasColumnName("id_inventario_herramienta");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.HerramientaId).HasColumnName("herramienta_id");

            entity.HasOne(d => d.Herramienta).WithMany(p => p.InventarioHerramienta)
                .HasForeignKey(d => d.HerramientaId)
                .HasConstraintName("FK_invherr_herr");
        });

        modelBuilder.Entity<InventarioMedicamento>(entity =>
        {
            entity.HasKey(e => e.IdInventarioMedicamento).HasName("PK__inventar__18335AF08E41C000");

            entity.ToTable("inventario_medicamento");

            entity.HasIndex(e => e.MedicamentoId, "IX_invmed_med");

            entity.Property(e => e.IdInventarioMedicamento).HasColumnName("id_inventario_medicamento");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Lote)
                .HasMaxLength(60)
                .HasColumnName("lote");
            entity.Property(e => e.MedicamentoId).HasColumnName("medicamento_id");

            entity.HasOne(d => d.Medicamento).WithMany(p => p.InventarioMedicamentos)
                .HasForeignKey(d => d.MedicamentoId)
                .HasConstraintName("FK_invmed_med");
        });

        modelBuilder.Entity<InventarioSuplemento>(entity =>
        {
            entity.HasKey(e => e.IdInventarioSuplemento).HasName("PK__inventar__4713B839E461C2E2");

            entity.ToTable("inventario_suplemento");

            entity.HasIndex(e => e.SuplementoId, "IX_invsup_sup");

            entity.Property(e => e.IdInventarioSuplemento).HasColumnName("id_inventario_suplemento");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Lote)
                .HasMaxLength(60)
                .HasColumnName("lote");
            entity.Property(e => e.SuplementoId).HasColumnName("suplemento_id");

            entity.HasOne(d => d.Suplemento).WithMany(p => p.InventarioSuplementos)
                .HasForeignKey(d => d.SuplementoId)
                .HasConstraintName("FK_invsup_sup");
        });

        modelBuilder.Entity<Maquinarium>(entity =>
        {
            entity.HasKey(e => e.IdMaquinaria).HasName("PK__maquinar__8B61DA97196A4E1C");

            entity.ToTable("maquinaria");

            entity.Property(e => e.IdMaquinaria).HasColumnName("id_maquinaria");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAdquisicion).HasColumnName("fecha_adquisicion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("PK__medicame__2588C03293C32130");

            entity.ToTable("medicamento");

            entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");
            entity.Property(e => e.DosisRecomendada)
                .HasMaxLength(60)
                .HasColumnName("dosis_recomendada");
            entity.Property(e => e.Laboratorio)
                .HasMaxLength(120)
                .HasColumnName("laboratorio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Montum>(entity =>
        {
            entity.HasKey(e => e.IdMonta).HasName("PK__monta__F9DB6DBDD719CBE2");

            entity.ToTable("monta");

            entity.HasIndex(e => e.HembraId, "IX_monta_hembra");

            entity.HasIndex(e => e.MachoId, "IX_monta_macho");

            entity.Property(e => e.IdMonta).HasColumnName("id_monta");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HembraId).HasColumnName("hembra_id");
            entity.Property(e => e.MachoId).HasColumnName("macho_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Hembra).WithMany(p => p.MontumHembras)
                .HasForeignKey(d => d.HembraId)
                .HasConstraintName("FK_monta_hembra");

            entity.HasOne(d => d.Macho).WithMany(p => p.MontumMachos)
                .HasForeignKey(d => d.MachoId)
                .HasConstraintName("FK_monta_macho");
        });

        modelBuilder.Entity<Mortalidad>(entity =>
        {
            entity.HasKey(e => e.IdMortalidad).HasName("PK__mortalid__42FF6BEA9F64AD7C");

            entity.ToTable("mortalidad");

            entity.HasIndex(e => e.AnimalId, "IX_mortalidad_animal");

            entity.HasIndex(e => e.EmpleadoId, "IX_mortalidad_emp");

            entity.Property(e => e.IdMortalidad).HasColumnName("id_mortalidad");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Causa)
                .HasMaxLength(255)
                .HasColumnName("causa");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");

            entity.HasOne(d => d.Animal).WithMany(p => p.Mortalidads)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_mortalidad_animal");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Mortalidads)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_mortalidad_empleado");
        });

        modelBuilder.Entity<Nacimiento>(entity =>
        {
            entity.HasKey(e => e.IdNacimiento).HasName("PK__nacimien__935CB01AABD68187");

            entity.ToTable("nacimiento");

            entity.HasIndex(e => e.CriaAnimalId, "IX_nac_cria");

            entity.HasIndex(e => e.MadreId, "IX_nac_madre");

            entity.Property(e => e.IdNacimiento).HasColumnName("id_nacimiento");
            entity.Property(e => e.CriaAnimalId).HasColumnName("cria_animal_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.MadreId).HasColumnName("madre_id");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("peso");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("sexo");

            entity.HasOne(d => d.CriaAnimal).WithMany(p => p.NacimientoCriaAnimals)
                .HasForeignKey(d => d.CriaAnimalId)
                .HasConstraintName("FK_nac_cria");

            entity.HasOne(d => d.Madre).WithMany(p => p.NacimientoMadres)
                .HasForeignKey(d => d.MadreId)
                .HasConstraintName("FK_nac_madre");
        });

        modelBuilder.Entity<Ordeno>(entity =>
        {
            entity.HasKey(e => e.IdOrdeno).HasName("PK__ordeno__6219D548B1E0A2A8");

            entity.ToTable("ordeno");

            entity.HasIndex(e => e.AnimalId, "IX_ordeno_animal");

            entity.HasIndex(e => e.OrdenadorId, "IX_ordeno_emp");

            entity.Property(e => e.IdOrdeno).HasColumnName("id_ordeno");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Litros)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("litros");
            entity.Property(e => e.OrdenadorId).HasColumnName("ordenador_id");
            entity.Property(e => e.Turno)
                .HasMaxLength(30)
                .HasColumnName("turno");

            entity.HasOne(d => d.Animal).WithMany(p => p.Ordenos)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_ordeno_animal");

            entity.HasOne(d => d.Ordenador).WithMany(p => p.Ordenos)
                .HasForeignKey(d => d.OrdenadorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ordeno_empleado");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__pago__0941B074E2283E88");

            entity.ToTable("pago");

            entity.HasIndex(e => e.FacturaId, "IX_pago_factura");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(60)
                .HasColumnName("tipo_pago");

            entity.HasOne(d => d.Factura).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_pago_factura");
        });

        modelBuilder.Entity<ParticipacionCapacitacion>(entity =>
        {
            entity.HasKey(e => e.IdParticipacion).HasName("PK__particip__E42D0FE089929319");

            entity.ToTable("participacion_capacitacion");

            entity.HasIndex(e => e.CapacitacionId, "IX_partcap_cap");

            entity.HasIndex(e => e.EmpleadoId, "IX_partcap_emp");

            entity.Property(e => e.IdParticipacion).HasColumnName("id_participacion");
            entity.Property(e => e.CapacitacionId).HasColumnName("capacitacion_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Resultado)
                .HasMaxLength(120)
                .HasColumnName("resultado");

            entity.HasOne(d => d.Capacitacion).WithMany(p => p.ParticipacionCapacitacions)
                .HasForeignKey(d => d.CapacitacionId)
                .HasConstraintName("FK_partcap_capacitacion");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ParticipacionCapacitacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_partcap_empleado");
        });

        modelBuilder.Entity<Planilla>(entity =>
        {
            entity.HasKey(e => e.IdPlanilla).HasName("PK__planilla__08D2C03E31AE58E9");

            entity.ToTable("planilla");

            entity.HasIndex(e => e.EmpleadoId, "IX_planilla_empleado");

            entity.Property(e => e.IdPlanilla).HasColumnName("id_planilla");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Deducciones)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("deducciones");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.HorasExtra)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("horas_extra");
            entity.Property(e => e.Mes).HasColumnName("mes");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("sueldo");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Planillas)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_planilla_empleado");
        });

        modelBuilder.Entity<Potrero>(entity =>
        {
            entity.HasKey(e => e.IdPotrero).HasName("PK__potrero__8C33F320F76D856C");

            entity.ToTable("potrero");

            entity.Property(e => e.IdPotrero).HasColumnName("id_potrero");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.Hectareas)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("hectareas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ProduccionCarne>(entity =>
        {
            entity.HasKey(e => e.IdProduccionCarne).HasName("PK__producci__529F2D68D663933B");

            entity.ToTable("produccion_carne");

            entity.HasIndex(e => e.AnimalId, "IX_prodcarne_animal");

            entity.Property(e => e.IdProduccionCarne).HasColumnName("id_produccion_carne");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Destino)
                .HasMaxLength(120)
                .HasColumnName("destino");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.PesoCanal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("peso_canal");

            entity.HasOne(d => d.Animal).WithMany(p => p.ProduccionCarnes)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_prodcarne_animal");
        });

        modelBuilder.Entity<ProduccionLeche>(entity =>
        {
            entity.HasKey(e => e.IdProduccionLeche).HasName("PK__producci__EDD0B54062D013B7");

            entity.ToTable("produccion_leche");

            entity.HasIndex(e => e.AnimalId, "IX_prodl_animal");

            entity.HasIndex(e => e.EmpleadoId, "IX_prodl_emp");

            entity.Property(e => e.IdProduccionLeche).HasColumnName("id_produccion_leche");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Litros)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("litros");

            entity.HasOne(d => d.Animal).WithMany(p => p.ProduccionLeches)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_prodl_animal");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ProduccionLeches)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_prodl_empleado");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0DDE2F9216");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioBase)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_base");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
            entity.Property(e => e.Unidad)
                .HasMaxLength(30)
                .HasColumnName("unidad");
        });

        modelBuilder.Entity<ProductoAlimenticio>(entity =>
        {
            entity.HasKey(e => e.IdProductoAlimenticio).HasName("PK__producto__C82FAF1C92FC4348");

            entity.ToTable("producto_alimenticio");

            entity.HasIndex(e => e.ProveedorId, "IX_prodalim_prov");

            entity.Property(e => e.IdProductoAlimenticio).HasColumnName("id_producto_alimenticio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.ProductoAlimenticios)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_prodalim_proveedor");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__proveedo__8D3DFE282E98EE2E");

            entity.ToTable("proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Contacto)
                .HasMaxLength(120)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoProveedor)
                .HasMaxLength(60)
                .HasColumnName("tipo_proveedor");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.IdRaza).HasName("PK__raza__084F250A4A6374C7");

            entity.ToTable("raza");

            entity.HasIndex(e => e.EspecieId, "IX_raza_especie");

            entity.Property(e => e.IdRaza).HasColumnName("id_raza");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.EspecieId).HasColumnName("especie_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Especie).WithMany(p => p.Razas)
                .HasForeignKey(d => d.EspecieId)
                .HasConstraintName("FK_raza_especie");
        });

        modelBuilder.Entity<RegistroParto>(entity =>
        {
            entity.HasKey(e => e.IdRegistroParto).HasName("PK__registro__5CE2131771B2AF21");

            entity.ToTable("registro_parto");

            entity.HasIndex(e => e.MadreId, "IX_regparto_madre");

            entity.Property(e => e.IdRegistroParto).HasColumnName("id_registro_parto");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.MadreId).HasColumnName("madre_id");
            entity.Property(e => e.NumeroCrias).HasColumnName("numero_crias");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.Madre).WithMany(p => p.RegistroPartos)
                .HasForeignKey(d => d.MadreId)
                .HasConstraintName("FK_regparto_madre");
        });

        modelBuilder.Entity<ReporteFinanciero>(entity =>
        {
            entity.HasKey(e => e.IdReporteFinanciero).HasName("PK__reporte___28DACDCBB2B27468");

            entity.ToTable("reporte_financiero");

            entity.HasIndex(e => e.EmpleadoId, "IX_rep_fin_emp");

            entity.Property(e => e.IdReporteFinanciero).HasColumnName("id_reporte_financiero");
            entity.Property(e => e.ArchivoUrl)
                .HasMaxLength(255)
                .HasColumnName("archivo_url");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.Egresos)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("egresos");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Ingresos)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ingresos");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ReporteFinancieros)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_rep_fin_emp");
        });

        modelBuilder.Entity<ReporteProduccion>(entity =>
        {
            entity.HasKey(e => e.IdReporteProduccion).HasName("PK__reporte___5E1633022FB8A539");

            entity.ToTable("reporte_produccion");

            entity.HasIndex(e => e.EmpleadoId, "IX_rep_prod_emp");

            entity.Property(e => e.IdReporteProduccion).HasColumnName("id_reporte_produccion");
            entity.Property(e => e.ArchivoUrl)
                .HasMaxLength(255)
                .HasColumnName("archivo_url");
            entity.Property(e => e.DatosResumen).HasColumnName("datos_resumen");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ReporteProduccions)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_rep_prod_emp");
        });

        modelBuilder.Entity<Suplemento>(entity =>
        {
            entity.HasKey(e => e.IdSuplemento).HasName("PK__suplemen__E7187F3638821FCC");

            entity.ToTable("suplemento");

            entity.Property(e => e.IdSuplemento).HasColumnName("id_suplemento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Nutrientes)
                .HasMaxLength(255)
                .HasColumnName("nutrientes");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.HasKey(e => e.IdTransporte).HasName("PK__transpor__7AC9B3AEBFD6E615");

            entity.ToTable("transporte");

            entity.Property(e => e.IdTransporte).HasColumnName("id_transporte");
            entity.Property(e => e.Capacidad)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("capacidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(60)
                .HasColumnName("estado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
            entity.Property(e => e.Vehiculo)
                .HasMaxLength(120)
                .HasColumnName("vehiculo");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__tratamie__C8825F4C519473EA");

            entity.ToTable("tratamiento");

            entity.Property(e => e.IdTratamiento).HasColumnName("id_tratamiento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(60)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PK__turno__C68E7397B0858FCD");

            entity.ToTable("turno");

            entity.HasIndex(e => e.EmpleadoId, "IX_turno_empleado");

            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK_turno_empleado");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04AD175325BA");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ContrasenaHash)
                .HasMaxLength(255)
                .HasColumnName("contrasena_hash");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.PermisosJson).HasColumnName("permisos_json");
            entity.Property(e => e.Rol)
                .HasMaxLength(60)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Vacuna>(entity =>
        {
            entity.HasKey(e => e.IdVacuna).HasName("PK__vacuna__BCC290CB52C85A8E");

            entity.ToTable("vacuna");

            entity.Property(e => e.IdVacuna).HasColumnName("id_vacuna");
            entity.Property(e => e.Dosis)
                .HasMaxLength(60)
                .HasColumnName("dosis");
            entity.Property(e => e.Fabricante)
                .HasMaxLength(120)
                .HasColumnName("fabricante");
            entity.Property(e => e.IntervaloDias).HasColumnName("intervalo_dias");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__venta__459533BFDFDAF903");

            entity.ToTable("venta");

            entity.HasIndex(e => e.ClienteId, "IX_venta_cliente");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(60)
                .HasColumnName("tipo_pago");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_venta_cliente");
        });

        modelBuilder.Entity<AnimalDto>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
