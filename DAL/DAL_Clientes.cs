using DAL.Context;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class DAL_Clientes
    {
        public static async Task<Clientes> Insert(Clientes entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            entidad.FechaRegistro = DateTime.Now;
            bd.Clientes.Add(entidad);
            await bd.SaveChangesAsync();
            return entidad;
        }

        public static async Task<bool> Update(Clientes entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Clientes.FindAsync(entidad.IdCliente);
            if (Registro != null)
            {
                Registro.Nombre = entidad.Nombre;
                Registro.DNI = entidad.DNI;
                Registro.Telefono = entidad.Telefono;
                Registro.Correo = entidad.Correo;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }

        public static async Task<bool> Anular(Clientes entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Clientes.FindAsync(entidad.IdCliente);
            if (Registro != null)
            {
                Registro.Activo = false;
                Registro.UsuarioActualiza = entidad.UsuarioActualiza;
                Registro.FechaActualiza = DateTime.Now;
            }
            return await BD.SaveChangesAsync() > 0;
        }

        public static async Task<List<Clientes>> Lista()
        {
            using BDSistemaVentas BD = new();
            return await BD.Clientes.Where(A => A.Activo).ToListAsync();
        }
    }
}
