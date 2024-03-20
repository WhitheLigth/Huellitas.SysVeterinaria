#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencia necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Breed_EN;
using Huellitas.SysVeterinaria.DAL.Breed___DAL;



#endregion

namespace Huellitas.SysVeterinaria.BL.Breed___BL
{
    public class BreedBL
    {
        #region METODO PARA GUARDAR
        // Metodo para guardar un nuevo registro a la base de datos
        public async Task<int> CreateAsync(Breed breed)
        {
            return await BreedDAL.CreateAsync(breed);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro existente en la base de datos
        public async Task<int> UpdateAsync(Breed breed)
        {
            return await BreedDAL.UpdateAsync(breed);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente en la base de datos
        public async Task<int> DeleteAsync(Breed breed)
        {
            return await BreedDAL.DeleteAsync(breed);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registro en base al id
        public async Task<Breed> GetByIdAsync(Breed breed)
        {
            return await BreedDAL.GetByIdAsync(breed);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<Breed>> GetAllAsync()
        {
            return await BreedDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public async Task<List<Breed>> SearchAsync(Breed breed)
        {
            return await BreedDAL.SearchAsync(breed);
        }
        #endregion
    }
}
