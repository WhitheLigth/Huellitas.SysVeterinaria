#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencia necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Pet_EN;
using Huellitas.SysVeterinaria.DAL.Pet___DAL;
#endregion

namespace Huellitas.SysVeterinaria.BL.Pet___BL
{
    public class PetBL
    {
        #region METODO PARA GUARDAR
        // Metodo para guardar un nuevo registro a la base de datos
        public async Task<int> CreateAsync(Pet pet)
        {
            return await PetDAL.CreateAsync(pet);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro existente en la base de datos
        public async Task<int> UpdateAsync(Pet pet)
        {
            return await PetDAL.UpdateAsync(pet);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente en la base de datos
        public async Task<int> DeleteAsync(Pet pet)
        {
            return await PetDAL.DeleteAsync(pet);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registro en base al id
        public async Task<Pet> GetByIdAsync(Pet pet)
        {
            return await PetDAL.GetByIdAsync(pet);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<Pet>> GetAllAsync()
        {
            return await PetDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public async Task<List<Pet>> SearchAsync(Pet pet)
        {
            return await PetDAL.SearchAsync(pet);
        }
        #endregion
    }
}
