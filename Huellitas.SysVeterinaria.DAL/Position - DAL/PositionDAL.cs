#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Huellitas.SysVeterinaria.EN.Position_EN;
using Huellitas.SysVeterinaria.EN.Services_EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace Huellitas.SysVeterinaria.DAL.Position___DAL
{
    public class PositionDAL
    {
        #region METODO PARA CREAR
        // Metodo para guardar un nuevo registro a la base de datos
        public static async Task<int> CreateAsync(Position position)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using(var dbContext = new ContextDB())
            {
                dbContext.Add(position);
                result = await dbContext.SaveChangesAsync();
            }
            return result; // Si se realizo con exito devuleve 1 si no devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modifiar un registro existente en la base de datos
        public static async Task<int> UpdateAsync(Position position)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using( var dbContext = new ContextDB())
            {
                var positionDB = await dbContext.Positions.FirstOrDefaultAsync(p => p.Id == position.Id);
                if (positionDB != null) 
                {
                    positionDB.Name = position.Name;

                    dbContext.Update(positionDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result; // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente de la base de datos
        public static async Task<int> DeleteAsync(Position position)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using( var dbContext = new ContextDB())
            {
                var positionDB = await dbContext.Positions.FirstOrDefaultAsync(p => p.Id == position.Id);
                if (positionDB != null)
                {
                    dbContext.Positions.Remove(positionDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro en base al id
        public static async Task<Position> GetByIdAsync(Position position)
        {
            var positionDB = new Position();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using(var dbContext = new ContextDB())
            {
                positionDB = await dbContext.Positions.FirstOrDefaultAsync(p => p.Id == position.Id);
            }
            return positionDB!;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<Position>> GetAllAsync()
        {
            var positions = new List<Position>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using( var dbContext = new ContextDB())
            {
                positions = await dbContext.Positions.ToListAsync();
            }
            return positions;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<Position> QuerySelect(IQueryable<Position> query, Position position)
        {
            // Por ID
            if (position.Id > 0)
                query = query.Where(p => p.Id == position.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(position.Name))
                query = query.Where(p => p.Name.Contains(position.Name));

            query = query.OrderByDescending(p => p.Id).AsQueryable();

            // Para la cantidad de registros a mostrar 
            if (position.Top_Aux > 0)
                query = query.Take(position.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<Position>> SearchAsync(Position position)
        {
            var positions = new List<Position>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using(var dbContext = new ContextDB())
            {
                var select = dbContext.Positions.AsQueryable();
                select = QuerySelect(select, position);
                positions = await select.ToListAsync();
            }
            return positions;
        }
        #endregion
    }
}
