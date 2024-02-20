using Huellitas.SysVeterinaria.DAL.Login;
using Huellitas.SysVeterinaria.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.BL.Login
{
    public class LoginBL
    {
        #region Metodo para crear un usuario nuevo
        public static async Task<int> CreateUserAsync(UserEN user)
        {
            return await LoginDAL.CreateUserAsync(user);
        }
        #endregion

        #region Metodo para iniciar sesion
        public static async Task<UserEN> GetUserByIdAsync(UserEN user)
        {
            return await LoginDAL.GetUserByIdAsync(user);
        }
        #endregion
    }
}
