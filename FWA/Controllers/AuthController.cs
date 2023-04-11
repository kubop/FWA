using FWAweb.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FWAweb.Controllers
{
    public class AuthController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login() { return View("Index"); }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([Bind("Login,Password")] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "User");
        }
    }
}
