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
    public static class DAL_DetalleIngreso
    {
        public static async Task<DetalleIngreso> Insert(DetalleIngreso entidad)
        {
            using BDSistemaVentas bd = new();
            bd.DetalleIngreso.Add(entidad);
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(DetalleIngreso entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.DetalleIngreso.FindAsync(entidad.IdDetalle);
            if (Registro != null)
            {
                Registro.Ingreso = entidad.Ingreso;
                Registro.Articulo = entidad.Articulo;
                Registro.PrecioCosto = entidad.PrecioCosto;
                Registro.Cantidad = entidad.Cantidad;
                Registro.PrecioVenta = entidad.PrecioVenta;
            }
            return await BD.SaveChangesAsync() > 0;
        }
    }
}
