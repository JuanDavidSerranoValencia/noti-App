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

    public DbSet<GenericoVsSubmodulo> GenericoVsSubmodulos { get; set; }
    public DbSet<MaestroVsSubmodulo> MaestroVsSubmodulos { get; set; }
    public DbSet<ModuloMaestro> ModuloMaestros { get; set; }
    public DbSet<PermisoGenerico> PermisoGenericos { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<RolMaestro> RolMaestros { get; set; }
    public DbSet<SubModulo> SubModulos { get; set; }
    public DbSet<Radicado> Radicados { get; set; }
    public DbSet<HiloRepuestaNoti> HiloRepuestaNotis { get; set; }
    public DbSet<Formato> Formatos { get; set; }
    public DbSet<BlockChain> BlockChains { get; set; }
    public DbSet<Auditoria> Auditorias { get; set; }
    public DbSet<TipoNoti> TipoNotis { get; set; }
    public DbSet<ModuloNotificacion> ModuloNotificacions { get; set; }
    public DbSet<EstadoNotificacion> EstadoNotificacions { get; set; }
     public DbSet<TipoRequerimiento> TipoRequerimientos { get; set; }

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
