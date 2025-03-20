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
    public static class DAL_Categorias
    {
        public static async Task<Categorias> Insert(Categorias entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            entidad.FechaRegistro = DateTime.Now;
            bd.Categorias.Add(entidad);
            await bd.SaveChangesAsync();
            return entidad;
        }

        public static async Task<bool> Update(Categorias entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Categorias.FindAsync(entidad.IdCategoria);
            if (Registro != null)
            {
                Registro.Categoria = entidad.Categoria;
                Registro.Descripcion = entidad.Descripcion;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }

        public static async Task<bool> Anular(Categorias entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Categorias.FindAsync(entidad.IdCategoria);
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
