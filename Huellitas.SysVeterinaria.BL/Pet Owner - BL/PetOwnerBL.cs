#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Huellitas.SysVeterinaria.DAL.Pet_Owner___DAL;
using Huellitas.SysVeterinaria.EN.Pet_Owner_EN;
#endregion

namespace Huellitas.SysVeterinaria.BL.Pet_Owner___BL
{
    public class PetOwnerBL
    {
        #region METODO PARA CREAR
        // Metodo para crear un nuevo registro en la base de datos
        public async Task<int> CreateAsync(PetOwner petOwner)
        {
            return await PetOwnerDAL.CreateAsync(petOwner);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente
        public async Task<int> UpdateAsync(PetOwner petOwner)
        {
            return await PetOwnerDAL.UpdateAsync(petOwner);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente
        public async Task<int> DeleteAsync(PetOwner petOwner)
        {
            return await PetOwnerDAL.DeleteAsync(petOwner);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registo en base a su id
        public async Task<PetOwner> GetByIdAsync(PetOwner petOwner)
        {
            return await PetOwnerDAL.GetByIdAsync(petOwner);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<PetOwner>> GetAllAsync()
        {
            return await PetOwnerDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSACAR
        // Metodo para buscar registros en la base de datos
        public async Task<List<PetOwner>> SearchAsync(PetOwner petOwner)
        {
            return await PetOwnerDAL.SearchAsync(petOwner);
        }
        #endregion
    }
}