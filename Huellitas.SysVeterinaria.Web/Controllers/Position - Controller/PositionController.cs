#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Microsoft.AspNetCore.Mvc;
using Huellitas.SysVeterinaria.BL.Position___BL;


#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.Position___Controller
{
    public class PositionController : Controller
    {
        // Creamos la instancia para acceder a los metodos
        PositionBL positionBL = new PositionBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion para mostrar la vista index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion que muestra el detalle de un registro
        public ActionResult Details(int id)
        {
            return View();
        }
        #endregion

        #region METODO PARA CREAR
        // Accion para mostrar la vista de crear
        public ActionResult Create()
        {
            return View();
        }

        // Accion que recibe los datos del formulario para ser enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Accion que muestra la vista de modificar
        public ActionResult Edit(int id)
        {
            return View();
        }

        // Accion que recibe los datos del formulario para ser enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Accion que muestra la vista de eliminar
        public ActionResult Delete(int id)
        {
            return View();
        }

        // Accion que recibe los datos del formulario para ser enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
