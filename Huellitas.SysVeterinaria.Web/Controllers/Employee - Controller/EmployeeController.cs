#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.BL.Employee___BL;
using Huellitas.SysVeterinaria.EN.Employee_EN;
using Microsoft.AspNetCore.Mvc;
using Huellitas.SysVeterinaria.BL.Position___BL;
using Huellitas.SysVeterinaria.EN.Position_EN;


#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.Employee___Controller
{
    public class EmployeeController : Controller
    {
        // Creamos la instancia para acceder a los metodos
        EmployeeBL employeeBL = new EmployeeBL();
        PositionBL positionBL = new PositionBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion Para Mostrar La Vista Index
        public async Task<IActionResult> Index(Employee employee = null!)
        {
            if (employee == null)
                employee = new Employee();
            if (employee.Top_Aux == 0)
                employee.Top_Aux = 10;
            else if (employee.Top_Aux == -1)
                employee.Top_Aux = 0;

            var employees = await employeeBL.SearchAsync(employee);
            var positions = await positionBL.GetAllAsync();

            ViewBag.Top = employee.Top_Aux;
            ViewBag.Positions = positions;
            return View(employees);
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion Que Muestra El Detalle De Un Registro
        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            employee.Position = await positionBL.GetByIdAsync(new Position { Id = employee.IdPosition });
            return View(employee);
        }
        #endregion

        #region METODO PARA CREAR
        // Accion Para Mostrar La Vista De Crear
        public async Task<ActionResult> Create()
        {
            ViewBag.Position = await positionBL.GetAllAsync();
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                employee.CreationDate = DateTime.Now;
                employee.ModificationDate = DateTime.Now;
                int result = await employeeBL.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Positions = await positionBL.GetAllAsync();
                return View();
            }
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Accion Que Muestra La Vista De Modificar
        public async Task<IActionResult> Edit(int id)
        {
            try 
            {
                var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });

                if(employee  == null)
                {
                    return NotFound();
                }

                ViewBag.Positions = await positionBL.GetAllAsync();
                return View(employee);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(); // Devolver la vista sin ningún objeto employee
            }
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            try
            {
                if(id != employee.Id)
                {
                    return BadRequest();
                }

                employee.ModificationDate = DateTime.Now;
                int result = await employeeBL.UpdateAsync(employee);
                TempData["SuccessMessageCreate"] = "Empleado Modificado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Positions = await positionBL.GetAllAsync();
                return View(employee);
            }
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Accion Que Muestra La Vista De Eliminar
        public async Task<IActionResult> Delete(Employee employee)
        {
            var employeeBD = await employeeBL.GetByIdAsync(employee);
            employeeBD.Position = await positionBL.GetByIdAsync(new Position { Id = employeeBD.IdPosition });
            ViewBag.Error = "";
            return View(employeeBD);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Employee employee)
        {
            try
            {
                Employee employeeBD = await employeeBL.GetByIdAsync(employee);
                int result = await employeeBL.DeleteAsync(employeeBD);
                TempData["SuccessMessageDelete"] = "Empleado Eliminado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                var employeeBD = await employeeBL.GetByIdAsync(employee);
                if (employeeBD == null)
                    employeeBD = new Employee();
                if(employeeBD.Id > 0)
                    employeeBD.Position = await positionBL.GetByIdAsync(new Position { Id = employeeBD.IdPosition });
                return View(employeeBD);
            }
        }
        #endregion
    }
}
