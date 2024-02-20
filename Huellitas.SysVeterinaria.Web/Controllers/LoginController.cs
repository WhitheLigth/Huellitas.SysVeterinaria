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

        #region Encriptar clave
        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        #endregion

        #region login
        public async Task<IActionResult> Login(int id)
        {
            var user = await LoginBL.GetUserByIdAsync(new UserEN { Id = id }); //Convertimos para mostrar muy bien 
            return View("Index", "Home");
        }
        #endregion
    }
}
