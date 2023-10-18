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
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
               builder.ToTable("auditoria");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p=>p.NombreUsuarioAuditoria)
            .IsRequired()
            .HasMaxLength(100);

             builder.Property(p=>p.DescAccion)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");

        }
    }
}