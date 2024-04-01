#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Microsoft.AspNetCore.Mvc;
using Huellitas.SysVeterinaria.BL.Position___BL;
using Huellitas.SysVeterinaria.BL.Services___BL;
using Huellitas.SysVeterinaria.EN.Services_EN;
using Huellitas.SysVeterinaria.EN.Position_EN;
using Huellitas.SysVeterinaria.DAL.Services___DAL;


#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.Position___Controller
{
    public class PositionController : Controller
    {
        // Creamos la instancia para acceder a los metodos
        PositionBL positionBL = new PositionBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion para mostrar la vista index
        public async Task<IActionResult> Index(Position position)
        {
            if (position == null)
                position = new Position();
            if (position.Top_Aux == 0)
                position.Top_Aux = 10;
            else if (position.Top_Aux == -1)
                position.Top_Aux = 0;

            var employees = await positionBL.SearchAsync(position);
            ViewBag.Top = position.Top_Aux;
            return View(employees);
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var position = await positionBL.GetByIdAsync(new Position { Id = id });
            return View(position);
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
        public async Task<IActionResult> Create(Position position)
        {
            try
            {
                int result = await positionBL.CreateAsync(position);
                TempData["SuccessMessageCreate"] = "Puesto o Cargo Agregado Exitosamente";
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
        // Accion que muestra la vista de modificar
        public async Task<IActionResult> Edit(int id)
        {
            var position = await positionBL.GetByIdAsync(new Position { Id = id });
            ViewBag.Error = "";
            return View(position);
        }

        //Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Position position)
        {
            try
            {
                int result = await positionBL.UpdateAsync(position);
                TempData["SuccessMessageUpdate"] = "Puesto o Cargo Modificado Exitosamente";
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
        // Accion que muestra la vista de eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var position = await positionBL.GetByIdAsync(new Position { Id = id });
            ViewBag.Error = "";
            return View(position);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Position position)
        {
            try
            {
                int result = await positionBL.DeleteAsync(position);
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
