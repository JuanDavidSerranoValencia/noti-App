using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class NotiAppContext : DbContext
{
    public NotiAppContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<GenericoVsSubmodulo> GenericosVsSubmodulos { get; set; }
    public DbSet<MaestroVsSubmodulo> MaestrosVsSubmodulos { get; set; }
    public DbSet<ModuloMaestro> ModulosMaestros { get; set; }
    public DbSet<PermisoGenerico> PermisosGenericos { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<RolMaestro> RolesMaestros { get; set; }
    public DbSet<SubModulo> SubsModulos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Cliente>()
       .HasOne(a => a.ClienteDireccion)
       .WithOne(b => b.Clientes)
       .HasForeignKey<ClienteDireccion>(b => b.IdCliente);*/

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
