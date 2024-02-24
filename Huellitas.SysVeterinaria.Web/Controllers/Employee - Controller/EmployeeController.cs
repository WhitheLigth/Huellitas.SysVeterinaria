using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Huellitas.SysVeterinaria.BL.Employee___BL;
using Huellitas.SysVeterinaria.EN.Employee_EN;

namespace Huellitas.SysVeterinaria.Web.Controllers.Employee___Controller
{
    public class EmployeeController : Controller
    {
        EmployeeBL employeeBL = new EmployeeBL();

        // GET: EmployeeController (accion que muestra el listado de las categorias)
        public async Task<IActionResult> Index(Employee employee = null)
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

        // GET: EmployeeController/Details/5 ( accion que muestra el detalle de un registro)
        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            return View(employee);
        }

        // GET: EmployeeController/Create (accion que MUESTRA el formulario para crear una categoria)
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: EmployeeController/Create (accion que recibe los datos del formulario para ser enviados a la basede datos)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                int result = await employeeBL.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Edit/5 (Accion que muestra el formulario para actualizar el registro)
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            ViewBag.Error = "";
            return View(employee);
        }

        // POST: EmployeeController/Edit/5 (Accion que recibe los datos modificados y los envia a la bd)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            try
            {
                int result = await employeeBL.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Delete/5 (Accion que muestra el formulario par eliminar)
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeeBL.GetByIdAsync(new Employee { Id = id });
            ViewBag.Error = "";
            return View(employee);
        }

        // POST: EmployeeController/Delete/5 (Accion que recibe los datos del formulario y los manda a la bd)
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
    }
}
