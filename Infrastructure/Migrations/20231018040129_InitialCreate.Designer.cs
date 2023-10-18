﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(NotiAppContext))]
    [Migration("20231018040129_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestroSubmoduloFk");

                    b.HasIndex("IdPermisoGenerioFk");

                    b.HasIndex("RolId");

                    b.ToTable("genericosvssubmodulos", (string)null);
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
                        .HasForeignKey("RolId");

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

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");

                    b.Navigation("RolesMaestros");
                });

            modelBuilder.Entity("Core.Entities.SubModulo", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");
                });
#pragma warning restore 612, 618
        }
    }
}
