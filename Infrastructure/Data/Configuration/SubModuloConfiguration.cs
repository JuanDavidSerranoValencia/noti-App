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
    public class SubModuloConfiguration : IEntityTypeConfiguration<SubModulo>
    {
        public void Configure(EntityTypeBuilder<SubModulo> builder)
        {
             builder.ToTable("submodulo");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p=>p.NombreSubmodulo)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .IsRequired()
            .HasColumnType("datetime");
        }
    }
}