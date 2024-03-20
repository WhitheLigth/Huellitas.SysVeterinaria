#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Pet_EN;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Huellitas.SysVeterinaria.DAL.Pet___DAL
{
    public class PetDAL
    {
        #region METODO PARA CREAR
        // Metodo para crear un nuevo registro en la base de datos
        public static async Task<int> CreateAsync(Pet pet)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                dbContext.Add(pet);
                result = await dbContext.SaveChangesAsync();
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente en la base de datos
        public static async Task<int> UpdateAsync(Pet pet)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var petDB = await dbContext.Pets.FirstOrDefaultAsync(p => p.Id == pet.Id);
                if (petDB != null)
                {
                    petDB.IdBreed = pet.IdBreed;
                    petDB.Name = pet.Name;
                    petDB.LastName = pet.LastName;
                    petDB.Age = pet.Age;
                    petDB.Gender = pet.Gender;
                    petDB.DistinctiveColorOrBrand = pet.DistinctiveColorOrBrand;
                    petDB.SpecialBehaviorOrNeed = pet.SpecialBehaviorOrNeed;
                    petDB.CreationDate = pet.CreationDate;
                    petDB.ModificationDate = pet.ModificationDate;

                    dbContext.Update(petDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro de la base de datos
        public static async Task<int> DeleteAsync(Pet pet)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var petDB = await dbContext.Pets.FirstOrDefaultAsync(p => p.Id == pet.Id);
                if (petDB != null)
                {
                    dbContext.Pets.Remove(petDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro por su id
        public static async Task<Pet> GetByIdAsync(Pet pet)
        {
            var petDB = new Pet();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                petDB = await dbContext.Pets.FirstOrDefaultAsync(p => p.Id == pet.Id);
            }
            return petDB;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<Pet>> GetAllAsync()
        {
            var pets = new List<Pet>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                pets = await dbContext.Pets.ToListAsync();
            }
            return pets;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS FILTRAR
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros) 
        internal static IQueryable<Pet> QuerySelect(IQueryable<Pet> query, Pet pet)
        {
            // Por ID
            if (pet.Id > 0)
                query = query.Where(p => p.Id == pet.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(pet.Name))
                query = query.Where(p => p.Name.Contains(pet.Name));

            query = query.OrderByDescending(p => p.Id).AsQueryable();

            // Para la cantidad de registros a mostrar 
            if (pet.Top_Aux > 0)
                query = query.Take(pet.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<Pet>> SearchAsync(Pet pet)
        {
            var pets = new List<Pet>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Pets.AsQueryable();
                select = QuerySelect(select, pet);
                pets = await select.ToListAsync();
            }
            return pets;
        }
        #endregion
    }
}
