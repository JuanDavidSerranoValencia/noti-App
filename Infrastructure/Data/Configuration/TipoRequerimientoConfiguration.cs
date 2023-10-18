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
    public class TipoRequerimientoConfiguration : IEntityTypeConfiguration<TipoRequerimiento>
    {
        public void Configure(EntityTypeBuilder<TipoRequerimiento> builder)
        {
              builder.ToTable("tiporequerimiento");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p=>p.NombreTipoRequerimiento)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}