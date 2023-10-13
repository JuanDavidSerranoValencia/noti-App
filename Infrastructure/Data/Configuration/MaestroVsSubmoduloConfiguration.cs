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
    public class MaestroVsSubmoduloConfiguration : IEntityTypeConfiguration<MaestroVsSubmodulo>
    {
        public void Configure(EntityTypeBuilder<MaestroVsSubmodulo> builder)
        {
            builder.ToTable("maestrovssubmodulo");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.FechaCreacion)
           .IsRequired()
           .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .IsRequired()
            .HasColumnType("datetime");

            builder.HasOne(p=>p.SubModulo)
            .WithMany(p=>p.MaestrosVsSubmodulos)
            .HasForeignKey(p=>p.IdSubModuloFk);

            builder.HasOne(p=>p.ModuloMaestro)
            .WithMany(p=> p.MaestrosVsSubmodulos)
            .HasForeignKey(p=>p.IdModuloMaestroFk);


        }
    }
}