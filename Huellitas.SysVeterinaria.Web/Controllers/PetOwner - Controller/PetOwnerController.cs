#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Huellitas.SysVeterinaria.BL.Pet_Owner___BL;
using Huellitas.SysVeterinaria.EN.Pet_Owner_EN;
using Microsoft.AspNetCore.Mvc;


#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.PetOwner___Controller
{
    public class PetOwnerController : Controller
    {

        PetOwnerBL petOwnerBL = new PetOwnerBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion Para Mostrar La Vista Index
        public async Task<IActionResult> Index(PetOwner petOwner = null)
        {
            if (petOwner == null)
                petOwner = new PetOwner();
            if (petOwner.Top_Aux == 0)
                petOwner.Top_Aux = 10;
            else if (petOwner.Top_Aux == -1)
                petOwner.Top_Aux = 0;

            var petOwners = await petOwnerBL.SearchAsync(petOwner);
            ViewBag.Top = petOwner.Top_Aux;
            return View(petOwners);
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion Que Muestra El Detalle De Un Registro
        public async Task<IActionResult> Details(int id)
        {
            var petOwner = await petOwnerBL.GetByIdAsync(new PetOwner { Id = id });
            return View(petOwner);
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
        public async Task<IActionResult> Create(PetOwner petOwner)
        {
            try
            {
                int result = await petOwnerBL.CreateAsync(petOwner);
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
            var petOwner = await petOwnerBL.GetByIdAsync(new PetOwner { Id = id });
            ViewBag.Error = "";
            return View(petOwner);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetOwner petOwner)
        {
            try
            {
                int result = await petOwnerBL.UpdateAsync(petOwner);
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
            var petOwner = await petOwnerBL.GetByIdAsync(new PetOwner { Id = id });
            ViewBag.Error = "";
            return View(petOwner);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, PetOwner petOwner)
        {
            try
            {
                int result = await petOwnerBL.DeleteAsync(petOwner);
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
