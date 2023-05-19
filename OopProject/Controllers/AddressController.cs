using BusinessLayer.Abstract;
using BusinessLayer.Validation_Rules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OopProject.Models;

namespace OopProject.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var values = _addressService.GetListAll();
            return View(values);
        }

        public IActionResult EditAddress(int id)
        {
            var value = _addressService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAddress(Address address)
        {

            AddressValidator av = new AddressValidator();
            ValidationResult result = av.Validate(address);
            if (result.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
