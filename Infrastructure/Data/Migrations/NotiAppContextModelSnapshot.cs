﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(NotiAppContext))]
    partial class NotiAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DescAccion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreUsuarioAuditoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("auditoria", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("HashGenerado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdAuditoriaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloRespuestaNotiFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoNotisFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAuditoriaFk");

                    b.HasIndex("IdHiloRespuestaNotiFk");

                    b.HasIndex("IdTipoNotisFk");

                    b.ToTable("blockchain", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EstadoNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreEstadoNotificacion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("estadonotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Formato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreFormato")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("formato", (string)null);
                });

            modelBuilder.Entity("Core.Entities.GenericoVsSubmodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdMaestroSubmoduloFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPermisoGenerioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestroSubmoduloFk");

                    b.HasIndex("IdPermisoGenerioFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("genericosvssubmodulos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.HiloRepuestaNoti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipoHilo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("hilorespuestanotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdModuloMaestroFk")
                        .HasColumnType("int");

                    b.Property<int>("IdSubModuloFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdModuloMaestroFk");

                    b.HasIndex("IdSubModuloFk");

                    b.ToTable("maestrovssubmodulo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreModulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("modulomaestro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AsuntoNotificacion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdEstadoNotiFk")
                        .HasColumnType("int");

                    b.Property<int>("IdFormatoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloNotiFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRadicadoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoNotisFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoRequerimientoFk")
                        .HasColumnType("int");

                    b.Property<string>("TextoNotificacion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoNotiFk");

                    b.HasIndex("IdFormatoFk");

                    b.HasIndex("IdHiloNotiFk");

                    b.HasIndex("IdRadicadoFk");

                    b.HasIndex("IdTipoNotisFk");

                    b.HasIndex("IdTipoRequerimientoFk");

                    b.ToTable("modulonotificaciones", (string)null);
                });

            modelBuilder.Entity("Core.Entities.PermisoGenerico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombrePermiso")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("pemrisogenerico", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("radicado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Core.Entities.RolMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdModuloMaestroFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdModuloMaestroFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("rolmaestro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.SubModulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreSubmodulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("submodulo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoNoti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipoNoti")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("tiponotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipoRequerimiento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tiporequerimiento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.HasOne("Core.Entities.Auditoria", "Auditoria")
                        .WithMany("BlocksChains")
                        .HasForeignKey("IdAuditoriaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRepuestaNoti", "HiloRepuestaNoti")
                        .WithMany("BlocksChains")
                        .HasForeignKey("IdHiloRespuestaNotiFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNoti", "TipoNoti")
                        .WithMany("BlocksChains")
                        .HasForeignKey("IdTipoNotisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditoria");

                    b.Navigation("HiloRepuestaNoti");

                    b.Navigation("TipoNoti");
                });

            modelBuilder.Entity("Core.Entities.GenericoVsSubmodulo", b =>
                {
                    b.HasOne("Core.Entities.MaestroVsSubmodulo", "MaestroVsSubmodulo")
                        .WithMany("GenericosVsModulos")
                        .HasForeignKey("IdMaestroSubmoduloFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.PermisoGenerico", "PermisoGenerico")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdPermisoGenerioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Rol")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaestroVsSubmodulo");

                    b.Navigation("PermisoGenerico");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestro", "ModuloMaestro")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdModuloMaestroFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.SubModulo", "SubModulo")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdSubModuloFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuloMaestro");

                    b.Navigation("SubModulo");
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificacion", b =>
                {
                    b.HasOne("Core.Entities.EstadoNotificacion", "EstadoNotificacion")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdEstadoNotiFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Formato", "Formato")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdFormatoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRepuestaNoti", "HiloRepuestaNoti")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdHiloNotiFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Radicado", "Radicado")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdRadicadoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNoti", "TipoNoti")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdTipoNotisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoRequerimiento", "TipoRequerimiento")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdTipoRequerimientoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoNotificacion");

                    b.Navigation("Formato");

                    b.Navigation("HiloRepuestaNoti");

                    b.Navigation("Radicado");

                    b.Navigation("TipoNoti");

                    b.Navigation("TipoRequerimiento");
                });

            modelBuilder.Entity("Core.Entities.RolMaestro", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestro", "ModuloMaestro")
                        .WithMany("RolesMaestros")
                        .HasForeignKey("IdModuloMaestroFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Rol")
                        .WithMany("RolesMaestros")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuloMaestro");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Navigation("BlocksChains");
                });

            modelBuilder.Entity("Core.Entities.EstadoNotificacion", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Formato", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.HiloRepuestaNoti", b =>
                {
                    b.Navigation("BlocksChains");

                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.Navigation("GenericosVsModulos");
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestro", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");

                    b.Navigation("RolesMaestros");
                });

            modelBuilder.Entity("Core.Entities.PermisoGenerico", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");

                    b.Navigation("RolesMaestros");
                });

            modelBuilder.Entity("Core.Entities.SubModulo", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.TipoNoti", b =>
                {
                    b.Navigation("BlocksChains");

                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
