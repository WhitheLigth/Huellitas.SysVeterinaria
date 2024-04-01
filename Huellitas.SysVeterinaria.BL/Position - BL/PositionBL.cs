#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Position_EN;
using Huellitas.SysVeterinaria.DAL.Position___DAL;


#endregion

namespace Huellitas.SysVeterinaria.BL.Position___BL
{
    public class PositionBL
    {
        #region METODO PARA GUARDAR
        // Metodo para guardar un nuevo registro a la base de datos
        public async Task<int> CreateAsync(Position position)
        {
            return await PositionDAL.CreateAsync(position);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro existente en la base de datos
        public async Task<int> UpdateAsync(Position position)
        {
            return await PositionDAL.UpdateAsync(position);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro extente en la base de datos
        public async Task<int> DeleteAsync(Position position)
        {
            return await PositionDAL.DeleteAsync(position);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registro en base al id
        public async Task<Position> GetByIdAsync(Position position)
        {
            return await PositionDAL.GetByIdAsync(position);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<Position>> GetAllAsync()
        {
            return await PositionDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public async Task<List<Position>> SearchAsync(Position position)
        {
            return await PositionDAL.SearchAsync(position);
        }
        #endregion
    }
}
