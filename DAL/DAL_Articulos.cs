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
    public static class DAL_Articulos
    {
        public static async Task<Articulos> Insert(Articulos entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            bd.Articulos.Add(entidad);
            entidad.FechaRegistro = DateTime.Now;
            await bd.SaveChangesAsync();
            return entidad;
        }
        public static async Task<bool> Update(Articulos entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Articulos.FindAsync(entidad.IdArticulo);
            if (Registro != null)
            {
                Registro.Articulo = entidad.Articulo;
                Registro.Descripcion = entidad.Descripcion;
                Registro.CodigoArticulo = entidad.CodigoArticulo;
                Registro.Categoria = entidad.Categoria;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<bool> Anular(Articulos entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Articulos.FindAsync(entidad.IdArticulo);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }
        public static async Task<List<Articulos>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.Articulos.Where(A => A.Activo).ToListAsync();
        }
    }
}
