using FWAcore.Model;
using FWAservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static FWAweb.Controllers.UserController;

namespace FWAweb.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: AddressController
        public ActionResult Index()
        {
            var addressList = _addressService.GetAllAddressesWithCount();
            return View(addressList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var address = _addressService.GetObjectById(id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,Street,Number,ZipCode,City")] Address address)
        {
            if (id != address.AddressId)
            {
                return NotFound();
            }

            var oldAddress = _addressService.GetObjectById(id);
            if (oldAddress == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _addressService.Update(address);
            }

            return RedirectToAction("Edit", id);
        }

        // TODO: Prerobiť na [HttpDelete] a na FE poslať custom DELETE request
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Address addressToDelete = _addressService.GetObjectById(id);
            if (addressToDelete == null)
            {
                return NotFound();
            }

            _addressService.SoftDelete(addressToDelete);

            return RedirectToAction("Index");
        }
    }
}
