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
    public static class DAL_Empleado
    {
        public static async Task<Empleado> Insert(Empleado entidad)
        {
            using BDSistemaVentas bd = new();
            entidad.Activo = true;
            bd.Empleado.Add(entidad);
            await bd.SaveChangesAsync();
            return entidad;
        }

        public static async Task<bool> Update(Empleado entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Empleado.FindAsync(entidad.IdEmpleado);
            if (Registro != null)
            {
                Registro.Nombre = entidad.Nombre;
                Registro.Apellido = entidad.Apellido;
                Registro.DNI = entidad.DNI;
                Registro.Username = entidad.Username;
                Registro.Password = entidad.Password;
            }
            return await BD.SaveChangesAsync() > 0;
        }

        public static async Task<bool> Anular(Empleado entidad)
        {
            using BDSistemaVentas BD = new();
            var Registro = await BD.Empleado.FindAsync(entidad.IdEmpleado);
            if (Registro != null)
            {
                Registro.Activo = false;
            }
            return await BD.SaveChangesAsync() > 0;
        }
    }
}