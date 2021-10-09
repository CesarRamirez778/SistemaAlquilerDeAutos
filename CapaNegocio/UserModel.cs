using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaComun.Cache;


namespace CapaNegocio
{
    public class UserModel
    {
        UserDato userDao = new UserDato();
        public bool LoginUser(string user,string pass)
        {
            return userDao.Login(user, pass);
        }

        //PRIVILEGIO DE USUARIOS
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
