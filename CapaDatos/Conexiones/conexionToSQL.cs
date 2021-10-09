using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.conexiones
{
   public abstract class conexionToSQL
    {
        private readonly string connectionString;

        //CONEXION TO DATABASE
        public conexionToSQL()
        {
            connectionString = "server=(local);DataBase=CarSystem; integrated security=true";
        }
        
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
