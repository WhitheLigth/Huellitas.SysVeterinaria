#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huellitas.SysVeterinaria.EN.Employee_EN;

// Referencias Necesarias Para El Correcto Funcionamiento
using Huellitas.SysVeterinaria.EN.Breed_EN;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Huellitas.SysVeterinaria.DAL.Breed___DAL
{
    public class BreedDAL
    {
        #region METODO PARA CREAR
        // Metodo para guardar un nuevo registro en la base de datos
        public static async Task<int> CreateAsync(Breed breed)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                dbContext.Add(breed);
                result = await dbContext.SaveChangesAsync();
            }
            return result; // Si se realizo con exito devuelve 1 si no devulve 0
        }
        #endregion

        #region  METODO PARA MODIFICAR
        // Metodo para modificar un registro existente en la base de datos
        public static async Task<int> UpdateAsync(Breed breed)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var breedDB = await dbContext.Breeds.FirstOrDefaultAsync(b => b.Id == breed.Id);
                if (breedDB != null)
                {
                    breedDB.Name = breed.Name;

                    dbContext.Update(breedDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result; // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMIANR
        // Metodo para eliminar un registro existente de la base de datos
        public static async Task<int> DeleteAsync(Breed breed)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var breedDB = await dbContext.Breeds.FirstOrDefaultAsync(b => b.Id == breed.Id);
                if (breedDB != null)
                {
                    dbContext.Remove(breedDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro en base al id
        public static async Task<Breed> GetByIdAsync(Breed breed)
        {
            var breedDB = new Breed();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                breedDB = await dbContext.Breeds.FirstOrDefaultAsync(b => b.Id == breed.Id);
            }
            return breedDB;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<Breed>> GetAllAsync()
        {
            var breeds = new List<Breed>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                breeds = await dbContext.Breeds.ToListAsync();
            }
            return breeds;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<Breed> QuerySelect(IQueryable<Breed> query, Breed breed)
        {
            // Por ID
            if (breed.Id > 0)
                query = query.Where(b => b.Id == breed.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(breed.Name))
                query = query.Where(b => b.Name.Contains(breed.Name));

            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO  PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<Breed>> SearchAsync(Breed breed)
        {
            var breeds = new List<Breed>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Breeds.AsQueryable();
                select = QuerySelect(select, breed);
                breeds = await select.ToListAsync();
            }
            return breeds;
        }
        #endregion
    }
}
