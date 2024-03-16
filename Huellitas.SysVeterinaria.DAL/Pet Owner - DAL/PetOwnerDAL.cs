#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Pet_Owner_EN;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Huellitas.SysVeterinaria.DAL.Pet_Owner___DAL
{
    public class PetOwnerDAL
    {
        #region METODO CREAR 
        public static async Task<int> CreateAsync(PetOwner petOwner)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                dbContext.Add(petOwner);
                await dbContext.SaveChangesAsync();
            }
            return result;
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente en la base de datos
        public static async Task<int> UpdateAsync(PetOwner petOwner)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var petOwnerDB = await dbContext.PetOwners.FirstOrDefaultAsync(p => p.Id == petOwner.Id);
                if (petOwnerDB != null)
                {
                    petOwnerDB.Name = petOwner.Name;
                    petOwnerDB.LastName = petOwner.LastName;
                    petOwnerDB.Dui = petOwner.Dui;
                    petOwnerDB.BirthDate = petOwner.BirthDate;
                    petOwnerDB.Age = petOwner.Age;
                    petOwnerDB.Gender = petOwner.Gender;
                    petOwnerDB.Address = petOwner.Address;
                    petOwnerDB.Phone = petOwner.Phone;
                    petOwnerDB.Email = petOwner.Email;
                    petOwnerDB.EmergencyNumber = petOwner.EmergencyNumber;

                    dbContext.Update(petOwnerDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro de la base de datos
        public static async Task<int> DeleteAsync(PetOwner petOwner)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var petOwnerDB = await dbContext.PetOwners.FirstOrDefaultAsync(a => a.Id == petOwner.Id);
                // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
                if (petOwnerDB != null)
                {
                    dbContext.PetOwners.Remove(petOwnerDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro por su id
        public static async Task<PetOwner> GetByIdAsync(PetOwner petOwner)
        {
            var petOwnerDB = new PetOwner();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                petOwnerDB = await dbContext.PetOwners.FirstOrDefaultAsync(p => p.Id == petOwner.Id);
            }
            return petOwnerDB;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<PetOwner>> GetAllAsync()
        {
            var petOwners = new List<PetOwner>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                petOwners = await dbContext.PetOwners.ToListAsync();
            }
            return petOwners;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS FILTRAR
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros) 
        internal static IQueryable<PetOwner> QuerySelect(IQueryable<PetOwner> query, PetOwner petOwner)
        {
            // Por ID
            if (petOwner.Id > 0)
                query = query.Where(c => c.Id == petOwner.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(petOwner.Name))
                query = query.Where(c => c.Name.Contains(petOwner.Name));

            // Se agrego por si se llega a utilizar
            if (!string.IsNullOrWhiteSpace(petOwner.Dui))
                query = query.Where(c => c.Dui.Contains(petOwner.Dui));

            query = query.OrderByDescending(c => c.Id).AsQueryable();

            // Para la cantidad de registros a mostrar 
            if (petOwner.Top_Aux > 0)
                query = query.Take(petOwner.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<PetOwner>> SearchAsync(PetOwner petOwner)
        {
            var petOwners = new List<PetOwner>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.PetOwners.AsQueryable();
                select = QuerySelect(select, petOwner);
                petOwners = await select.ToListAsync();
            }
            return petOwners;
        }
        #endregion
    }
}