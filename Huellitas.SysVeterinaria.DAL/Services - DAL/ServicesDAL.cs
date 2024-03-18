#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huellitas.SysVeterinaria.EN.Employee_EN;

// Referencias Necesarias Para El Correcto Funcionamiento
using Huellitas.SysVeterinaria.EN.Services_EN;
using Microsoft.EntityFrameworkCore;



#endregion

namespace Huellitas.SysVeterinaria.DAL.Services___DAL
{
    public class ServicesDAL
    {
        #region METODO PARA CREAR
        // Metodo para guardar un nuevo registro en la base de datos
        public static async Task<int> CreateAsync(Service service)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using(var dbContext = new ContextDB())
            {
                dbContext.Add(service);
                result = await dbContext.SaveChangesAsync();
            }
            return result; // Si se realizo con exito devuelve 1 si no devulve 0
        }
        #endregion

        #region  METODO PARA MODIFICAR
        // Metodo para modificar un registro existente en la base de datos
        public static async Task<int> UpdateAsync(Service service)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using(var dbContext = new ContextDB())
            {
                var serviceDB = await dbContext.Services.FirstOrDefaultAsync(s => s.Id == service.Id);
                if(serviceDB != null)
                {
                    serviceDB.Name = service.Name;
                    serviceDB.Price = service.Price;
                    serviceDB.DurationTime = service.DurationTime;
                    serviceDB.Status = service.Status;
                    serviceDB.Description = service.Description;

                    dbContext.Update(serviceDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result; // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMIANR
        // Metodo para eliminar un registro existente de la base de datos
        public static async Task<int> DeleteAsync(Service service)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using( var dbContext = new ContextDB())
            {
                var serviceDB = await dbContext.Services.FirstOrDefaultAsync(s => s.Id == service.Id);
                if(serviceDB != null)
                {
                    dbContext.Services.Remove(serviceDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro en base al id
        public static async Task<Service> GetByIdAsync(Service service)
        {
            var serviceDB = new Service();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using( var dbContext = new ContextDB())
            {
                serviceDB = await dbContext.Services.FirstOrDefaultAsync(s => s.Id == service.Id);
            }
            return serviceDB;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<Service>> GetAllAsync()
        {
            var services = new List<Service>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using( var dbContext = new ContextDB())
            {
                services = await dbContext.Services.ToListAsync();
            }
            return services;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<Service> QuerySelect(IQueryable<Service> query, Service service)
        {
            // Por ID
            if (service.Id > 0)
                query = query.Where(c => c.Id == service.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(service.Name))
                query = query.Where(c => c.Name.Contains(service.Name));

            query = query.OrderByDescending(c => c.Id).AsQueryable();

            // Para la cantidad de registros a mostrar 
            if (service.Top_Aux > 0)
                query = query.Take(service.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO  PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<Service>> SearchAsync(Service service)
        {
            var services = new List<Service>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using(var dbContext = new ContextDB())
            {
                var select = dbContext.Services.AsQueryable();
                select = QuerySelect(select, service);
                services = await select.ToListAsync();
            }
            return services;
        }
        #endregion
    }
}
