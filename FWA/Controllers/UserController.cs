using FWAservices;
using Microsoft.AspNetCore.Mvc;
using FWAcore.Model;

namespace FWAweb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly AddressService _addressService;

        public UserController(UserService userService, AddressService addressService) 
        {
            _userService = userService;
            _addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userService.ListForGrid();
            return View(users);
        }

        public class UserAddressesModel
        {
            public User User { get; set; }
            public IList<Address> Addresses { get; set; } = new List<Address>();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = _userService.GetObjectById(id);
            if (user == null)
            {
                return NotFound();
            }

            var addressList = _addressService.GetAllAddresses();

            var model = new UserAddressesModel
            {
                User = user,
                Addresses = addressList
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,Login,Password,AddressId")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Budeme savovať
            }

            return RedirectToAction("Edit", id);
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
