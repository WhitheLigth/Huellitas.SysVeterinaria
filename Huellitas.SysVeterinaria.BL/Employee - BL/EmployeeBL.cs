#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Huellitas.SysVeterinaria.DAL.Employee___DAL;
using Huellitas.SysVeterinaria.EN.Employee_EN;


#endregion


namespace Huellitas.SysVeterinaria.BL.Employee___BL
{
    public class EmployeeBL
    {
        #region METODO PARA CREAR
        // Metodo para crear un nuevo registro en la base de datos
        public async Task<int> CreateAsync(Employee employee)
        {
            return await EmployeeDAL.CreateAsync(employee);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente
        public async Task<int> UpdateAsync(Employee employee)
        {
            return await EmployeeDAL.UpdateAsync(employee);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro existente
        public async Task<int> DeleteAsync(Employee employee)
        {
            return await EmployeeDAL.DeleteAsync(employee);
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo para obtener un registo en base a su id
        public async Task<Employee> GetByIdAsync(Employee employee)
        {
            return await EmployeeDAL.GetByIdAsync(employee);
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public async Task<List<Employee>> GetAllAsync()
        {
            return await EmployeeDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA BUSACAR
        // Metodo para buscar registros en la base de datos
        public  async Task<List<Employee>> SearchAsync(Employee employee)
        {
            return await EmployeeDAL.SearchAsync(employee);
        }
        #endregion
    }
}