#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.BL.Employee___BL;
using Huellitas.SysVeterinaria.EN.Employee_EN;
using Microsoft.AspNetCore.Mvc;


#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.Employee___Controller
{
    public class EmployeeController : Controller
    {
        // Creamos la instancia para acceder a los metodos
        EmployeeBL employeeBL = new EmployeeBL();

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
            ViewBag.Top = employee.Top_Aux;
            return View(employees);
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion Que Muestra El Detalle De Un Registro
        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            return View(employee);
        }
        #endregion

        #region METODO PARA CREAR
        // Accion Para Mostrar La Vista De Crear
        public ActionResult Create()
        {
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
                return View();
            }
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Accion Que Muestra La Vista De Modificar
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            ViewBag.Error = "";
            return View(employee);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            try
            {
                employee.ModificationDate = DateTime.Now;
                int result = await employeeBL.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Accion Que Muestra La Vista De Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            ViewBag.Error = "";
            return View(employee);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Employee employee)
        {
            try
            {
                int result = await employeeBL.DeleteAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        #endregion
    }
}
