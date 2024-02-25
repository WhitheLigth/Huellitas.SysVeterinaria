using Huellitas.SysVeterinaria.EN.Employee_EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellitas.SysVeterinaria.DAL.Employee___DAL
{
    public class EmployeeDAL
    {
        #region Metodo de agregar (Create)
        // El STATIC sirve para tener acceso sin necesidad de hacer una instancia 
        // El async significa que las peticiones se haran en donde haya cupo (usando todos los recursos de la PC) para que sea mas fluido 
        // Task si se trabaja con async siempre (C#) se usara TASK por que async devuelve una tarea (task) 
        public static async Task<int> CreateAsync (Employee employee)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque l base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                dbContext.Add(employee);
                result = await dbContext.SaveChangesAsync(); // Await sirve para esperar a terminar todos los procesos para devolverlos todos juntos
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region Metodo de Actualizar (Update)
        public static async Task<int> UpdateAsync(Employee employee)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var employeeDB = await dbContext.Employee.FirstOrDefaultAsync(c => c.Id == employee.Id);
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
                    employeeDB.CertifWorkExperienceication = employee.CertifWorkExperienceication;
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

        #region Metodo Eliminar (Delete or Remove)
        public static async Task<int> DeleteAsync(Employee employee)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var employeeDB = await dbContext.Employee.FirstOrDefaultAsync(a => a.Id == employee.Id);
                if (employeeDB != null)
                {
                    dbContext.Employee.Remove(employeeDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo Mostrar por ID
        public static async Task<Employee> GetByIdAsync(Employee employee)
        {
            var employeeDB = new Employee();
            using (var dbContext = new ContextDB())
            {
                employeeDB = await dbContext.Employee.FirstOrDefaultAsync(c => c.Id == employee.Id);
            }
            return employeeDB;
        }
        #endregion

        #region Mostrar todos
        public static async Task<List<Employee>> GetAllAsync()
        {
            var employees = new List<Employee>();
            using (var dbContext = new ContextDB())
            {
                employees = await dbContext.Employee.ToListAsync();
            }
            return employees;
        }
        #endregion

        #region Metodo de Buscar Registros mediante el uso de filtros (Por Id, Por Nombre y por DUI)
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

        #region Metodo de buscar
        public static async Task<List<Employee>> SearchAsync(Employee employee)
        {
            var employees = new List<Employee>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Employee.AsQueryable();
                select = QuerySelect(select, employee);
                employees = await select.ToListAsync();
            }
            return employees;
        }
        #endregion
    }
}
