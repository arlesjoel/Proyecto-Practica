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
    public static class DAL_Venta
    {
        public static async Task<Venta> Insert(Venta entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            bd.Venta.Add(entidad);
            entidad.FechaRegistro = DateTime.Now;
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(Venta entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Venta.FindAsync(entidad.IdVenta);
            if (Registro != null)
            {
                Registro.Empleado = entidad.Empleado;
                Registro.Cliente = entidad.Cliente;
                Registro.SubTotal = entidad.SubTotal;
                Registro.IVA = entidad.IVA;
                Registro.Total = entidad.Total;
                Registro.Fecha = entidad.Fecha;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<bool> Anular(Venta entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Venta.FindAsync(entidad.IdVenta);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<List<Venta>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.Venta.Where(A => A.Activo).ToListAsync();
        }
    }
}