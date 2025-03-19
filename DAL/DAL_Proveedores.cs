using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using EL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class DAL_Proveedores
    {
        public static async Task<Proveedores> Insert(Proveedores entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            entidad.FechaRegistro = DateTime.Now;
            bd.Proveedores.Add(entidad);
            await bd.SaveChangesAsync();
            return entidad;
        }

        public static async Task<bool> Update(Proveedores entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Proveedores.FindAsync(entidad.IdProveedor);
            if (Registro != null)
            {
                Registro.Proveedor = entidad.Proveedor;
                Registro.RUC = entidad.RUC;
                Registro.Telefono = entidad.Telefono;
                Registro.Correo = entidad.Correo;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }

        public static async Task<bool> Anular(Proveedores entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Proveedores.FindAsync(entidad.IdProveedor);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
    }
}
