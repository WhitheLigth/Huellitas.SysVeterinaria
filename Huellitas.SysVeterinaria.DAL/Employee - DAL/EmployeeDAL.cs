#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.EN.Employee_EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace Huellitas.SysVeterinaria.DAL.Employee___DAL
{
    public class EmployeeDAL
    {
        #region METODO PARA CREAR
        // Metodo para crear un nuevo registro en la base de datos
        public static async Task<int> CreateAsync (Employee employee)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                dbContext.Add(employee);
                result = await dbContext.SaveChangesAsync();
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo para modificar un registro ya existente en la base de datos
        public static async Task<int> UpdateAsync(Employee employee)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var employeeDB = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employee.Id);
                if (employeeDB != null)
                {
                    employeeDB.Name = employee.Name;
                    employeeDB.LastName = employee.LastName;
                    employee.Dui = employee.Dui;
                    employeeDB.BirthDate = employee.BirthDate;
                    employeeDB.Age = employee.Age;
                    employeeDB.Gender = employee.Gender;
                    employeeDB.CivilStatus = employee.CivilStatus;
                    employeeDB.Address = employee.Address;
                    employeeDB.Phone = employee.Phone;
                    employeeDB.Email = employee.Email;
                    employeeDB.EmergencyNumber = employee.EmergencyNumber;
                    employeeDB.AcademicTitle = employee.AcademicTitle;
                    employeeDB.WorkExperience = employee.WorkExperience;
                    employeeDB.AreaOfSpecialization = employee.AreaOfSpecialization;
                    employeeDB.Position = employee.Position;
                    employeeDB.KnownAllergies = employee.KnownAllergies;
                    employeeDB.RelevantMedicalConditions = employee.RelevantMedicalConditions;
                    employeeDB.CreationDate = employee.CreationDate;
                    employeeDB.ModificationDate = employee.ModificationDate;

                    dbContext.Update(employeeDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo para eliminar un registro de la base de datos
        public static async Task<int> DeleteAsync(Employee employee)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var employeeDB = await dbContext.Employees.FirstOrDefaultAsync(a => a.Id == employee.Id);
                // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
                if (employeeDB != null)
                {
                    dbContext.Employees.Remove(employeeDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo para mostrar un registro por su id
        public static async Task<Employee> GetByIdAsync(Employee employee)
        {
            var employeeDB = new Employee();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                employeeDB = await dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employee.Id);
            }
            return employeeDB;
        }
        #endregion

        #region METODO PARA MOSTRAR LA LISTA DE REGISTROS
        // Metodo para obtener toda la lista de registros y mostrarlos
        public static async Task<List<Employee>> GetAllAsync()
        {
            var employees = new List<Employee>();
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                employees = await dbContext.Employees.ToListAsync();
            }
            return employees;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS FILTRAR
        // Metodo para filtrar la busqueda
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros) 
        internal static IQueryable<Employee> QuerySelect(IQueryable<Employee> query, Employee employee)
        {
            // Por ID
            if (employee.Id > 0)
                query = query.Where(c => c.Id == employee.Id);

            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(employee.Name))
                query = query.Where(c => c.Name.Contains(employee.Name));

            // Se agrego por si se llega a utilizar
            if (!string.IsNullOrWhiteSpace(employee.Dui))
                query = query.Where(c => c.Dui.Contains(employee.Dui));

            query = query.OrderByDescending(c => c.Id).AsQueryable();

            // Para la cantidad de registros a mostrar 
            if (employee.Top_Aux > 0)
                query = query.Take(employee.Top_Aux).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para buscar registros en la base de datos
        public static async Task<List<Employee>> SearchAsync(Employee employee)
        {
            var employees = new List<Employee>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Employees.AsQueryable();
                select = QuerySelect(select, employee);
                employees = await select.ToListAsync();
            }
            return employees;
        }
        #endregion
    }
}
