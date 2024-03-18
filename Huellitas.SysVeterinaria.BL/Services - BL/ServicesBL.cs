#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencia necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.DAL.Services___DAL;
using Huellitas.SysVeterinaria.EN.Services_EN;



#endregion

namespace Huellitas.SysVeterinaria.BL.Services___BL
{
    public class ServicesBL
    {
        #region METODO PARA GUARDAR
        // Metodo para guardar un nuevo registro a la base de datos
        public async Task<int> CreateAsync(Service service)
        {
            return await ServicesDAL.CreateAsync(service);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro existente en la base de datos
        public async Task<int> UpdateAsync(Service service)
        {
            return await ServicesDAL.UpdateAsync(service);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente en la base de datos
        public async Task<int> DeleteAsync(Service service)
        {
            return await ServicesDAL.DeleteAsync(service);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registro en base al id
        public async Task<Service> GetByIdAsync(Service service)
        {
            return await ServicesDAL.GetByIdAsync(service);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<Service>> GetAllAsync()
        {
            return await ServicesDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public async Task<List<Service>> SearchAsync(Service service)
        {
            return await ServicesDAL.SearchAsync(service);
        }
        #endregion

    }
}
