﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSistemaTransporte.DataAccess.Data;

#nullable disable

namespace ProyectoSistemaRepositorio.DataAccess.Migrations
{
    [DbContext(typeof(SistemaTrasnporteDbContext))]
    [Migration("20240321060130_SegundaMigracionCampoPDF")]
    partial class SegundaMigracionCampoPDF
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Conductor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdConductor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Edad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conductor");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdMarca");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipovehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipovehiculoId");

                    b.ToTable("Marca");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Toyota",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(172),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(187),
                            TipovehiculoId = 1,
                            UrlImagen = "link",
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Kia",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(191),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(192),
                            TipovehiculoId = 1,
                            UrlImagen = "link",
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Hyunday",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(194),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(195),
                            TipovehiculoId = 1,
                            UrlImagen = "link",
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        });
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdModelo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Corrola",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2022),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2026),
                            MarcaId = 1,
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Sportage",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2031),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2032),
                            MarcaId = 1,
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Santa Fe",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2033),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(2034),
                            MarcaId = 1,
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        });
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.RegistroVehicular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdRegistroVehicular");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConductorId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCaducidad")
                        .HasColumnType("DATE");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("DATE");

                    b.Property<string>("UrlPdf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConductorId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("RegistroVehicular");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdTipoVehiculo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoVehiculo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Automovil",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5815),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5820),
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "MotoTaxi",
                            Estado = true,
                            FechaCreacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5825),
                            FechaModificacion = new DateTime(2024, 3, 21, 1, 1, 30, 411, DateTimeKind.Local).AddTicks(5826),
                            UsuarioCreacion = "administrador",
                            UsuarioModificacion = "administrador"
                        });
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdVehiculo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDAsiento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("TipoVehiculoId");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Marca", b =>
                {
                    b.HasOne("ProyectoSistemaTransporte.Entidades.TipoVehiculo", "TipoVehiculo")
                        .WithMany("Marcas")
                        .HasForeignKey("TipovehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Modelo", b =>
                {
                    b.HasOne("ProyectoSistemaTransporte.Entidades.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.RegistroVehicular", b =>
                {
                    b.HasOne("ProyectoSistemaTransporte.Entidades.Conductor", "Conductor")
                        .WithMany("RegistroVehiculars")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoSistemaTransporte.Entidades.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conductor");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Vehiculo", b =>
                {
                    b.HasOne("ProyectoSistemaTransporte.Entidades.Marca", "Marca")
                        .WithMany("Vehiculos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoSistemaTransporte.Entidades.Modelo", "Modelo")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoSistemaTransporte.Entidades.TipoVehiculo", "TipoVehiculo")
                        .WithMany("Vehiculos")
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Modelo");

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Conductor", b =>
                {
                    b.Navigation("RegistroVehiculars");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Marca", b =>
                {
                    b.Navigation("Modelos");

                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.Modelo", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("ProyectoSistemaTransporte.Entidades.TipoVehiculo", b =>
                {
                    b.Navigation("Marcas");

                    b.Navigation("Vehiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
