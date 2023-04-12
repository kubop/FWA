using FWAservices;
using FWAweb.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FWAweb.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Login() 
        { 
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "User");
            }
            return View("Index"); 
        }

        [AllowAnonymous]
        public IActionResult LoginMicrosoft()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "User");
            }
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Login,Password")] LoginModel model, string? returnUrl)
        {
            var a = HttpContext;
            var user = _userService.GetObjectByName(model.Login);
            if (user == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid username or password");
                return View("Index");
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Login)
                    },
                    CookieAuthenticationDefaults.AuthenticationScheme
                )
            ));

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "User");
        }
    }
}
