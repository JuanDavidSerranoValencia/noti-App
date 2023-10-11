using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class NotiAppContext : DbContext
{
    public NotiAppContext(DbContextOptions options) : base(options)
    {
    }
    
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
