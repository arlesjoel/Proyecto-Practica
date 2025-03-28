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
    public static class DAL_Ingreso
    {
        public static async Task<Ingreso> Insert(Ingreso entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            entidad.FechaRegistro = DateTime.Now;
            bd.Ingreso.Add(entidad);
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(Ingreso entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Ingreso.FindAsync(entidad.IdIngreso);
            if (Registro != null)
            {
                Registro.Empleado = entidad.Empleado;
                Registro.Proveedor = entidad.Proveedor;   
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<bool> Anular(Ingreso entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Ingreso.FindAsync(entidad.IdIngreso);
            if (Registro != null)
            {
                Registro.Activo = false;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<List<Ingreso>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.Ingreso.Where(A => A.Activo).ToListAsync();
        }
    }
}
