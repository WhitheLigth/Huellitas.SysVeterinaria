using Microsoft.AspNetCore.Http;

using Huellitas.SysVeterinaria.BL.Login;
using Huellitas.SysVeterinaria.EN;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;


namespace Huellitas.SysVeterinaria.Web.Controllers
{
    public class LoginController : Controller
    {
        #region login
        public async Task<IActionResult> Login(int id)
        {
            var user = await LoginBL.GetUserByIdAsync(new UserEN { Id = id }); //Convertimos para mostrar muy bien 
            return View("Index", "Home");
        }
        #endregion
    }
}
