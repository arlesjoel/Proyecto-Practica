using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using EL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public static class DAL_DetalleVenta
    {
        public static async Task<DetalleVenta> Insert(DetalleVenta entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            bd.DetalleVenta.Add(entidad);
            entidad.FechaRegistro = DateTime.Now;
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(DetalleVenta entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.DetalleVenta.FindAsync(entidad.IdDetalleVenta);
            if (Registro != null)
            {
                Registro.Articulo = entidad.Articulo;
                Registro.Venta = entidad.Venta;
                Registro.Ingreso = entidad.Ingreso;
                Registro.PrecioVenta = entidad.PrecioVenta;
                Registro.Cantidad = entidad.Cantidad;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<bool> Anular(DetalleVenta entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.DetalleVenta.FindAsync(entidad.IdDetalleVenta);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<List<DetalleVenta>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.DetalleVenta.Where(A => A.Activo).ToListAsync();
        }
    }
}