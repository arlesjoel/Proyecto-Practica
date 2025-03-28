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
    public static class DAL_MovimientoInventario
    {
        public static async Task<MovimientoInventario> Insert(MovimientoInventario entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            bd.MovimientoInventario.Add(entidad);
            entidad.FechaRegistro = DateTime.Now;
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(MovimientoInventario entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.MovimientoInventario.FindAsync(entidad.IdMovimiento);
            if (Registro != null)
            {
                Registro.Ingreso = entidad.Ingreso;
                Registro.Articulo = entidad.Articulo;
                Registro.CantidadSalida = entidad.CantidadSalida;
                Registro.FechaMovimiento = entidad.FechaMovimiento;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<bool> Anular(MovimientoInventario entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.MovimientoInventario.FindAsync(entidad.IdMovimiento);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<List<MovimientoInventario>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.MovimientoInventario.Where(A => A.Activo).ToListAsync();
        }
    }
}