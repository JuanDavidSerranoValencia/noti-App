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
    public class EstadoNotificacionConfiguration : IEntityTypeConfiguration<EstadoNotificacion>
    {
        public void Configure(EntityTypeBuilder<EstadoNotificacion> builder)
        {
            builder.ToTable("estadonotificacion");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.NombreEstadoNotificacion)
            .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .IsRequired()
            .HasColumnType("datetime");
        }
    }
}