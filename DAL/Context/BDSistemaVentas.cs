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
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Ingreso> Ingreso { get; set; }
        public DbSet<DetalleIngreso> DetalleIngreso { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
