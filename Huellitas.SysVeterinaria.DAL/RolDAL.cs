using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Huellitas.SysVeterinaria.EN.Rol;
using Microsoft.EntityFrameworkCore;


namespace Huellitas.SysVeterinaria.DAL
{
    public class RolDAL
    {
        #region Metodo de Create
        public static async Task<int> CreateAsync(RolEN rolEN)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                dbContext.Add(rolEN);
                await dbContext.SaveChangesAsync();
            }
            return result;
        }
        #endregion

        #region Metodo de Edit Rol
        public static async Task<int> UpdateAsync(RolEN rolEN)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var rolDb = await dbContext.Rol.FirstOrDefaultAsync(a => a.Id == rolEN.Id);
                if (rolDb != null)
                {
                    rolDb.Id = rolEN.Id;
                    rolDb.Name = rolEN.Name;

                    dbContext.Update(rolDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo de Delete
        public static async Task<int> DeleteAsync(RolEN rolEN)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var rolDb = await dbContext.Rol.FirstOrDefaultAsync(a => a.Id == rolEN.Id);
                if (rolDb != null)
                {
                    dbContext.Remove(rolDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo de Read All (Mostrar)
        public static async Task<List<RolEN>> GetAllAsync()
        {
            var rols = new List<RolEN>();
            using (var dbContext = new ContextDB())
            {
                rols = await dbContext.Rol.ToListAsync();
            }
            return rols;
        }
        #endregion

        #region Metodo de Read By Id (Mostrar)
        public static async Task<RolEN> GetByIdAsync(RolEN rolEN)
        {

            var rolDB = new RolEN();
            using (var dbContext = new ContextDB())
            {
                rolDB = await dbContext.Rol.FirstOrDefaultAsync(a => a.Id == rolEN.Id);
            }
            return rolDB;
        }
        #endregion

        #region Metodo de Search 
        internal static IQueryable<RolEN> QuerySelect(IQueryable<RolEN> query, RolEN rolEN)
        {
            //Por ID 
            if (rolEN.Id > 0)
                query = query.Where(c => c.Id == rolEN.Id);

            //Por Nombre
            if (!string.IsNullOrWhiteSpace(rolEN.Name))
                query = query.Where(c => c.Name.Contains(rolEN.Name));

            //Para ordenar descendentemente o ascendentemente 
            query = query.OrderByDescending(c => c.Id).AsQueryable();
            return query;
        }

        // Queda pendiente de agregar este metodo al completo (No se si utilizaremos el Top-Aux)

        public static async Task<List<RolEN>> SearchAsync(RolEN rolEN)
        {
            var rols = new List<RolEN>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Rol.AsQueryable();
                select = QuerySelect(select, rolEN);
                rols = await select.ToListAsync();
            }
            return rols;
        }
        #endregion
    }
}