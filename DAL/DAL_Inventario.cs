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
    public static class DAL_Inventario
    {
        public static async Task<Inventario> Insert(Inventario entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            bd.Inventario.Add(entidad);
            entidad.FechaRegistro = DateTime.Now;
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(Inventario entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Inventario.FindAsync(entidad.IdInventario);
            if (Registro != null)
            {
                Registro.Ingreso = entidad.Ingreso;
                Registro.Articulo = entidad.Articulo;
                Registro.Cantidad = entidad.Cantidad;
                Registro.PrecioVenta = entidad.PrecioVenta;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<bool> Anular(Inventario entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Inventario.FindAsync(entidad.IdInventario);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<List<Inventario>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.Inventario.Where(A => A.Activo).ToListAsync();
        }
    }
}
