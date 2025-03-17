using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Conexion
    {
        private struct Connection
        {
            public string ApplicationName { get; set; }
            public string Server { get; set; }
            public string UserName { get; set; }
            public string UserPassword { get; set; }
            public string DataBase { get; set; }
        }
        public static string GetConnectionStringDev(bool SqlAuthentication = false)
        {
            return BuildConexionString(Developer, SqlAuthentication);
        }
        private static string BuildConexionString(Connection Connection, bool SqlAutentication = true)
        {
            SqlConnectionStringBuilder Constructor = new()
            {
                ApplicationName = Connection.ApplicationName,
                DataSource = Connection.Server,
                InitialCatalog = Connection.DataBase,
                IntegratedSecurity = !SqlAutentication,
                TrustServerCertificate = true
            };
            if (SqlAutentication)
            {
                Constructor.UserID = Connection.UserName;
                Constructor.Password = Connection.UserPassword;
            }
            //if (!SqlAutentication)
            //{
            Constructor.TrustServerCertificate = true;
            //}
            return Constructor.ConnectionString;
        }
        static readonly Connection Developer = new()
        {
            ApplicationName = "SIM",
            Server = @"DESKTOP-9VH7CLA",
            UserName = "",
            UserPassword = "",
            DataBase = "SistemaVentas"

        };


    }
}
