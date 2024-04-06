#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Huellitas.SysVeterinaria.DAL.User___DAL;
using Huellitas.SysVeterinaria.EN.User_EN;


#endregion


namespace Huellitas.SysVeterinaria.BL.User___BL
{
    public class UserBL
    {
        #region METODO PARA CREAR
        // Metodo para crear un nuevo registro en la base de datos
        public async Task<int> CreateAsync(User user)
        {
            return await UserDAL.CreateAsync(user);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente
        public async Task<int> UpdateAsync(User user)
        {
            return await UserDAL.UpdateAsync(user);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente
        public async Task<int> DeleteAsync(User user)
        {
            return await UserDAL.DeleteAsync(user);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registo en base a su id
        public async Task<User> GetByIdAsync(User user)
        {
            return await UserDAL.GetByIdAsync(user);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<User>> GetAllAsync()
        {
            return await UserDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public async Task<List<User>> SearchAsync(User user)
        {
            return await UserDAL.SearchAsync(user);
        }
        #endregion

        #region METODO PARA INCLUIR EL ROL
        public async Task<List<User>> SearchIncludeRolAsync(User user)
        {
            return await UserDAL.SearchIncludeRolAsync(user);
        }
        #endregion

        #region METODO PARA VALIDAR LOGIN
        public async Task<User> LoginAsync(User user)
        {
            return await UserDAL.LoginAsync(user);
        }
        #endregion

        #region METODO PARA VALIDAR LOGIN
        public async Task<int> ChangePasswordAsync(User user, string oldPassword)
        {
            return await UserDAL.ChangePasswordAsync(user, oldPassword);
        }
        #endregion
    }
}
