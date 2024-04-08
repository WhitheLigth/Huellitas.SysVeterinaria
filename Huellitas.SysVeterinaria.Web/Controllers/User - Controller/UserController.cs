using Huellitas.SysVeterinaria.BL.Role___BL;
using Huellitas.SysVeterinaria.BL.User___BL;
using Huellitas.SysVeterinaria.EN.Rol_EN;
using Huellitas.SysVeterinaria.EN.User_EN;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Huellitas.SysVeterinaria.Web.Controllers.User___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Administrador")] //protegemos el controlador para el publico
    public class UserController : Controller
    {
        UserBL userBL = new UserBL();
        RoleBL roleBL = new RoleBL();


        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index(User user = null)
        {
            if (user == null)
                user = new User();

            if (user.Top_Aux == 0)
                user.Top_Aux = 10; //setear el numero de registros a mostrar (se puede cambiar al numero que queramos mostrar)

            else if (user.Top_Aux == -1)
                user.Top_Aux = 0;

            var users = await userBL.SearchIncludeRoleAsync(user);
            var roles = await roleBL.GetAllAsync();
            ViewBag.Roles = roles;

            ViewBag.Top = user.Top_Aux;
            return View(users);
        }

        // GET: UserController/Details/5 (Accion que muestra los detalles de un registro)
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        public async Task<IActionResult> Details(int id)
        {
            var user = await userBL.GetByIdAsync(new User { Id = id });
            user.Role = await roleBL.GetByIdAsync(new Role { Id = user.IdRole }); //Para mostrar la relacion entre ROL y USER
            return View(user);
        }

        // GET: UserController/Create (Accion que muestra el formulario para un registro nuevo)
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        public async Task<IActionResult> Create()
        {
            var roles = await roleBL.GetAllAsync();
            ViewBag.Roles = roles;
            return View();
        }

        // POST: UserController/Create
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                int reult = await userBL.CreateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await roleBL.GetAllAsync();//Si da error nos mantiene en la vista
                return View(user);
            }
        }

        // GET: UserController/Edit/5 (Accion que muestra el formulario con los datos guardador para modifircar)
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        public async Task<ActionResult> Edit(int id)
        {
            var user = await userBL.GetByIdAsync(new User { Id = id });
            user.Role = await roleBL.GetByIdAsync(new Role { Id = user.IdRole }); //Para mostrar la relacion entre ROL y USER
            ViewBag.Roles = await roleBL.GetAllAsync();

            ViewBag.Erro = "";
            return View(user);
        }

        // POST: UserController/Edit/5 (Accion que recibe los datos modificador y los envia a la bd)
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            try
            {
                int result = await userBL.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await roleBL.GetAllAsync();
                return View(user);
            }
        }

        // GET: UserController/Delete/
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userBL.GetByIdAsync(new User { Id = id });
            user.Role = await roleBL.GetByIdAsync(new Role { Id = user.IdRole }); //Para mostrar la relacion entre ROL y USER

            ViewBag.Erro = "";
            return View(user);
        }

        // POST: UserController/Delete/ (Accion que elimina el registro)
        [Authorize(Roles = "Administrador")] //proteger para que solo el admin lo vea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, User user)
        {
            try
            {
                int result = await userBL.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var userDb = await userBL.GetByIdAsync(user);

                if (userDb == null)
                    userDb = new User();

                if (userDb.Id > 0)
                    userDb.Role = await roleBL.GetByIdAsync(new Role { Id = userDb.IdRole });

                return View(userDb);
            }
        }

        //Accion que muestra el formulario de inicio de sesion
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Url = returUrl;
            ViewBag.Error = "";

            return View();
        }

        // Accion que ejecuta la autenticacion del usuarios
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user, string returUrl = null)
        {
            try
            {
                var userDb = await userBL.LoginAsync(user);
                if (userDb != null && userDb.Id > 0 && userDb.Login == user.Login)
                {
                    userDb.Role = await roleBL.GetByIdAsync(new Role { Id = userDb.IdRole });

                    var claims = new[] { new Claim(ClaimTypes.Name, userDb.Login), new Claim(ClaimTypes.Role, userDb.Role.Name) };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);//identitad basada en los claims

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                }
                else
                {
                    throw new Exception("Hay un problema con sus credenciales");
                }

                if (!string.IsNullOrEmpty(returUrl))         //Verificamos que la url no este vacioa
                    return Redirect(returUrl);
                else
                    return RedirectToAction("Index", "Home"); // redirecionamos a la pantalla principal
            }
            catch (Exception ex)
            {
                ViewBag.Url = returUrl;
                ViewBag.Error = ex.Message;
                return View(new User { Login = user.Login });
            }
        }

        //Accion que permite cerrar la sesion del usuario
        [AllowAnonymous]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        //Accion muestra el formulario para cambiar contraseña
        public async Task<IActionResult> ChangePassword()
        {
            var users = await userBL.SearchAsync(new User { Login = User.Identity.Name, Top_Aux = 1 });
            var actualUser = users.FirstOrDefault();

            return View(actualUser);
        }

        //Accion que recibe la contraseña actualizada y la envia a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(User user, string oldPassword)
        {
            try
            {
                int result = await userBL.ChangePasswordAsync(user, oldPassword);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var users = await userBL.SearchAsync(new User { Login = User.Identity.Name, Top_Aux = 1 });
                var actualUser = users.FirstOrDefault();

                return View(actualUser);
            }
        }
    }
}
