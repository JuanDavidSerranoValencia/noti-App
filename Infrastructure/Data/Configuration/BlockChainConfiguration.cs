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
    public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
              builder.ToTable("blockchain");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p=>p.HashGenerado)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");
            
            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");

            builder.HasOne(p=>p.TipoNoti)
            .WithMany(p=>p.BlocksChains)
            .HasForeignKey(p=>p.IdTipoNotisFk);

            builder.HasOne(p=>p.HiloRespuestaNoti)
            .WithMany(p=>p.BlocksChains)
            .HasForeignKey(p=>p.IdHiloRespuestaNotiFk);

            builder.HasOne(p=>p.Auditoria)
            .WithMany(p=>p.BlocksChains)
            .HasForeignKey(p=>p.IdAuditoriaFk);

        }
    }
}