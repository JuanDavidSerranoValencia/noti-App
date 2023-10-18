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
    public class ModuloNotificacionConfiguration : IEntityTypeConfiguration<ModuloNotificacion>
    {
        public void Configure(EntityTypeBuilder<ModuloNotificacion> builder)
        {
            builder.ToTable("modulonotificaciones");


            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id);

            builder.Property(p=>p.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p=>p.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(2000);



            builder.HasOne(P=>P.TipoNoti)
            .WithMany(P=>P.ModulosNotificaciones)
            .HasForeignKey(P=>P.IdTipoNotisFk);

            builder.HasOne(P=>P.Radicado)
            .WithMany(P=>P.ModulosNotificaciones)
            .HasForeignKey(P=>P.IdRadicadoFk);

            builder.HasOne(P=>P.EstadoNotificacion)
            .WithMany(P=>P.ModulosNotificaciones)
            .HasForeignKey(P=>P.IdEstadoNotiFk);

            builder.HasOne(P=>P.HiloRepuestaNoti)
            .WithMany(P=>P.ModulosNotificaciones)
            .HasForeignKey(P=>P.IdHiloNotiFk);

            builder.HasOne(P=>P.Formato)
            .WithMany(P=>P.ModulosNotificaciones)
            .HasForeignKey(P=>P.IdFormatoFk);

            builder.HasOne(P=>P.TipoRequerimiento)
            .WithMany(P=>P.ModulosNotificaciones)
            .HasForeignKey(P=>P.IdTipoRequerimientoFk);


        }
    }
}