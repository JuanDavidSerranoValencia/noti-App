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
    public class TipoNotiConfiguration : IEntityTypeConfiguration<TipoNoti>
    {
        public void Configure(EntityTypeBuilder<TipoNoti> builder)
        {
            builder.ToTable("tiponotificacion");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.NombreTipoNoti)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}