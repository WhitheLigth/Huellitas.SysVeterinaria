using Huellitas.SysVeterinaria.DAL.Employee___DAL;
using Huellitas.SysVeterinaria.EN.Employee_EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.BL.Employee___BL
{
    public class EmployeeBL
    {
        #region Metodo de agregar (Create)
        public async Task<int> CreateAsync(Employee employee)
        {
            return await EmployeeDAL.CreateAsync(employee);
        }
        #endregion

        #region Metodo de Actualizar (Update)
        public async Task<int> UpdateAsync(Employee employee)
        {
            return await EmployeeDAL.UpdateAsync(employee);
        }
        #endregion

        #region Metodo Eliminar (Delete or Remove)
        public async Task<int> DeleteAsync(Employee employee)
        {
            return await EmployeeDAL.DeleteAsync(employee);
        }
        #endregion

        #region Metodo Mostrar por ID
        public async Task<Employee> GetByIdAsync(Employee employee)
        {
            return await EmployeeDAL.GetByIdAsync(employee);
        }
        #endregion

        #region Mostrar todos
        public async Task<List<Employee>> GetAllAsync()
        {
            return await EmployeeDAL.GetAllAsync();
        }
        #endregion

        #region Metodo de buscar
        public  async Task<List<Employee>> SearchAsync(Employee employee)
        {
            return await EmployeeDAL.SearchAsync(employee);
        }
        #endregion
    }
}
