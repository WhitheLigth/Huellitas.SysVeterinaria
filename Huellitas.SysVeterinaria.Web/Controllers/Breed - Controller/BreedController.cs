#region REFERENCIAS
using Microsoft.AspNetCore.Http;
// Referencias necesarias para el correcto funcionamiento
using Microsoft.AspNetCore.Mvc;
using Huellitas.SysVeterinaria.BL.Breed___BL;
using Huellitas.SysVeterinaria.EN.Breed_EN;


#endregion

namespace Huellitas.SysVeterinaria.Web.Controllers.Breed___Controller
{
    public class BreedController : Controller
    {
        // Creamos la instancia para acceder a los metodos
        BreedBL breedBL = new BreedBL();

        #region METODO PARA MOSTRAR INDEX
        // Accion que muestra la vista Index
        public async Task<IActionResult> Index(Breed breed)
        {
            if (breed == null)
                breed = new Breed();
            if (breed.Top_Aux == 0)
                breed.Top_Aux = 10;
            else if (breed.Top_Aux == -1)
                breed.Top_Aux = 0;

            var breeds = await breedBL.SearchAsync(breed);
            ViewBag.Top = breed.Top_Aux;
            return View(breeds);
        }
        #endregion

        #region METODO PARA MOSTRAR DETALLES
        // Accion que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var breed = await breedBL.GetByIdAsync(new Breed { Id = id });
            return View(breed);
        }
        #endregion

        #region METODO PARA CREAR
        // Accion que muestra la vista de crear
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Breed breed)
        {
            try
            {
                int result = await breedBL.CreateAsync(breed);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Accion Que Muestra La Vista de Modificar
        public async Task<IActionResult> Edit(int id)
        {
            var breed = await breedBL.GetByIdAsync(new Breed { Id = id });
            ViewBag.Error = "";
            return View(breed);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Breed breed)
        {
            try
            {
                int result = await breedBL.UpdateAsync(breed);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Accion Que Muestra La Vista De Eliminar
        public async Task<IActionResult> Delete(int id)
        {
            var breed = await breedBL.GetByIdAsync(new Breed { Id = id });
            ViewBag.Error = "";
            return View(breed);
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Breed breed)
        {
            try
            {
                int result = await breedBL.DeleteAsync(breed);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        #endregion
    }
}
