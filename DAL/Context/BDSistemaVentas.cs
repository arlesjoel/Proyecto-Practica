using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using DAL;
using Microsoft.Extensions.Configuration;


namespace DAL.Context
{
    public class BDSistemaVentas : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { _ = optionsBuilder.UseSqlServer(Conexion.GetConnectionStringDev()); }

        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
