#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Microsoft.AspNetCore.Mvc;
using Huellitas.SysVeterinaria.BL.Services___BL;
using Huellitas.SysVeterinaria.EN.Services_EN;
using Huellitas.SysVeterinaria.BL.Employee___BL;
using Huellitas.SysVeterinaria.EN.Employee_EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;



#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.Service___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)] //protegemos el controlador para el publico
    public class ServiceController : Controller
    {
        // Creamos la instancia para acceder a los metodos
        ServicesBL servicesBL = new ServicesBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion para mostrar la vista index
        public async Task<IActionResult> Index(Service service)
        {
            if (service == null)
                service = new Service();
            if (service.Top_Aux == 0)
                service.Top_Aux = 10;
            else if (service.Top_Aux == -1)
                service.Top_Aux = 0;

            var employees = await servicesBL.SearchAsync(service);
            ViewBag.Top = service.Top_Aux;
            return View(employees);
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion que muestre el detalle de un registro
        public async Task<IActionResult> Details (int id)
        {
            var service = await servicesBL.GetByIdAsync(new Service { Id = id });
            return View(service);
        }
        #endregion

        #region METODO PARA CREAR
        // Accion para mostrar la vista de crear
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            try
            {
                int result = await servicesBL.CreateAsync(service);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
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
            var service = await servicesBL.GetByIdAsync(new Service { Id = id });
            ViewBag.Error = "";
            return View(service);
        }

        //Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Service service)
        {
            try
            {
                int result = await servicesBL.UpdateAsync(service);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
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
            var service = await servicesBL.GetByIdAsync(new Service { Id = id });
            ViewBag.Error = "";
            return View(service);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Service service)
        {
            try
            {
                int result = await servicesBL.DeleteAsync(service);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        #endregion
    }
}
