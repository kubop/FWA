using FWAservices;
using Microsoft.AspNetCore.Mvc;
using FWAcore.Model;

namespace FWAweb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userService.ListForGrid();
            return View(users);
        }

        // TODO: Prerobiť na [HttpDelete] a na FE poslať custom DELETE request
        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            User userToDelete = _userService.GetObjectById(id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            _userService.SoftDelete(userToDelete);

            return RedirectToAction("Index");
        }
    }
}
