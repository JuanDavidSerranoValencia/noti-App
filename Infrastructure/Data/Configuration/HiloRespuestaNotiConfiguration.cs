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
    public class HiloRespuestaNotiConfiguration : IEntityTypeConfiguration<HiloRepuestaNoti>
    {
        public void Configure(EntityTypeBuilder<HiloRepuestaNoti> builder)
        {
            builder.ToTable("hilorespuestanotificacion");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p=>p.NombreTipoHilo)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}