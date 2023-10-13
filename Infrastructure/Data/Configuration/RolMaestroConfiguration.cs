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
    public class RolMaestroConfiguration : IEntityTypeConfiguration<RolMaestro>
    {
        public void Configure(EntityTypeBuilder<RolMaestro> builder)
        {
             builder.ToTable("rol");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);


            builder.Property(p => p.FechaCreacion)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .IsRequired()
            .HasColumnType("datetime");

            builder.HasOne(p=> p.Rol)
            .WithMany(p=>p.RolesMaestros)
            .HasForeignKey(p=>p.IdRolFk);

            builder.HasOne(p=>p.ModuloMaestro)
            .WithMany(p=>p.RolesMaestros)
            .HasForeignKey(p=>p.IdModuloMaestroFk);
        }
    }
}