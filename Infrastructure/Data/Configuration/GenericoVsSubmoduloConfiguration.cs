using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class GenericoVsSubmoduloConfiguration : IEntityTypeConfiguration<GenericoVsSubmodulo>
    {

        public void Configure(EntityTypeBuilder<GenericoVsSubmodulo> builder)
        {
            builder.ToTable("genericosvssubmodulos");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p=>p.FechaCreacion)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(p=>p.FechaModificacion)
            .IsRequired()
            .HasColumnType("datetime");

            builder.HasOne(p=>p.PermisoGenerico)
            .WithMany(p=>p.GenericosVsSubmodulos)
            .HasForeignKey(p=>p.IdPermisoGenerioFk);

            builder.HasOne(p=>p.MaestroVsSubmodulo)
            .WithMany(p =>p.GenericosVsModulos)
            .HasForeignKey(p=>p.IdMaestroSubmoduloFk);

            builder.HasOne(p=>p.Rol)
            .WithMany(p=>p.GenericosVsSubmodulos)
            .HasForeignKey(p =>p.IdRolFk);
        }
    }
}