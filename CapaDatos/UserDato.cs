using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaComun.Cache;

namespace CapaDatos
    
{
   public class UserDato:conexiones.conexionToSQL
    { 

        public bool Login(string user,string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select*from Users where LoginName=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.IdUser = reader.GetInt32(0);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Email = reader.GetString(6);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        // PRIVILEGIO DE USUARIO
             public void AnyMethod()
             {
                if (UserLoginCache.Position == Positions.Administrador)
                {
                    
                }

                if (UserLoginCache.Position == Positions.Soporte || UserLoginCache.Position == Positions.Empleado)
                { 
                    
                }
             }
            

















    }
              
}
