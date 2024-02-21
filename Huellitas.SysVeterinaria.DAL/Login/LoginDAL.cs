using Huellitas.SysVeterinaria.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.DAL.Login
{
    public class LoginDAL
    {
        #region Metodo para crear nuevo usuario
        public static async Task<int> CreateUserAsync(UserEN user)
        {
            int result = 0;
            using(var dbContext = new ContextDB())
            {
                dbContext.Add(user);
                await dbContext.SaveChangesAsync();
            }
            return result;
        }
        #endregion

        #region Metodo para iniciar sesion
        public static async Task<UserEN> GetUserByIdAsync(UserEN user) //-traera el id del usario que estamos ingresando en el controller
        {                                                               
            var UserDB = new UserEN();
            using(var dbContext = new ContextDB())
            {
                UserDB = await dbContext.User.FirstOrDefaultAsync(c => c.Id == user.Id);
            }
            return UserDB;
        }
        #endregion
    }
}
