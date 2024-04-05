#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.User_EN;
using Microsoft.EntityFrameworkCore;


#endregion


namespace Huellitas.SysVeterinaria.DAL.User___DAL
{
    public class UserDAL
    {
        #region METODO PARA CREAR
        // Metodo para crear un nuevo registro en la base de datos
        public static async Task<int> CreateAsync(User user)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                bool userExists = await ExistRole(user, dbContext);
                if (userExists == false)
                {
                    dbContext.Add(user);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("User Ya Existente, Vuelve a Intentarlo");
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente en la base de datos
        public static async Task<int> UpdateAsync(User user)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var userDB = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (userDB != null)
                {
                    bool userExists = await ExistUser(user, dbContext);
                    if (userExists == false)
                    {
                        userDB.Name = user.Name;
                        userDB.LastName = user.LastName;
                        userDB.Dui = user.Dui;
                        userDB.UserName = user.UserName;
                        userDB.Password = user.Password;
                        userDB.IdRol = user.IdRol;

                        dbContext.Update(userDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                        throw new Exception("Empleado Ya Existente, Vuelve a Intentarlo");
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro de la base de datos
        public static async Task<int> DeleteAsync(User user)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var userDB = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (userDB != null)
                {
                    dbContext.Users.Remove(userDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro por su id
        public static async Task<User> GetByIdAsync(User user)
        {
            var userDB = new User();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                userDB = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            }
            return userDB!;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<User>> GetAllAsync()
        {
            var users = new List<User>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                users = await dbContext.Users.ToListAsync();
            }
            return users;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS FILTRAR
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros) 
        internal static IQueryable<User> QuerySelect(IQueryable<User> query, User user)
        {
            // Por ID
            if (user.Id > 0)
                query = query.Where(c => c.Id == user.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(user.Name))
                query = query.Where(c => c.Name.Contains(user.Name));

            // Se agrego por si se llega a utilizar
            if (!string.IsNullOrWhiteSpace(user.Dui))
                query = query.Where(c => c.Dui.Contains(user.Dui));

            query = query.OrderByDescending(c => c.Id).AsQueryable();

            // Para la cantidad de registros a mostrar 
            if (user.Top_Aux > 0)
                query = query.Take(user.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<User>> SearchAsync(User user)
        {
            var users = new List<User>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Users.AsQueryable();
                select = QuerySelect(select, user);
                users = await select.ToListAsync();
            }
            return users;
        }
        #endregion

        #region METODO PARA INCLUIR A Rol
        // Metodo para incluir el Rol para la busqueda
        public static async Task<List<User>> SearchIncludeRolAsync(User user)
        {
            var users = new List<User>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Users.AsQueryable();
                select = QuerySelect(select, user).Include(u => u.Rol).AsQueryable();
                users = await select.ToListAsync();
            }
            return users;
        }
        #endregion

        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo para validar que sea unica existencia del registro en base al Dui/Id
        private static async Task<bool> ExistUser(User user, ContextDB dbContext)
        {
            bool result = false;
            var users = await dbContext.Users.FirstOrDefaultAsync(r => r.Dui == user.Dui && r.Id != user.Id);
            if (users != null && users.Id > 0 && users.Dui == user.Dui)
                result = true;

            return result;
        }
        #endregion
    }
}
