using FWAservices;
using Microsoft.AspNetCore.Mvc;

namespace FWAweb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            // int id = 2;
            var users = _userService.ListForGrid();

            return View(users);
        }
    }
}
