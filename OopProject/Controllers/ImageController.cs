using BusinessLayer.Abstract;
using BusinessLayer.Validation_Rules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace OopProject.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _ımageService;

        public ImageController(IImageService ımageService)
        {
            _ımageService = ımageService;
        }

        public IActionResult Index()
        {
            var values = _ımageService.GetListAll();
            return View(values);
        }



        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(Image i)
        {
            ImageValidator iv = new ImageValidator();
            ValidationResult result = iv.Validate(i);
            if (result.IsValid)
            {
                _ımageService.Insert(i);
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
        public IActionResult DeleteImage(int id)
        {
            var value = _ımageService.GetById(id);
            _ımageService.Delete(value);
            return RedirectToAction("Index");
        }
        public IActionResult EditImage(int id)
        {
            var value = _ımageService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditImage(Image i)
        {

            ImageValidator iv = new ImageValidator();
            ValidationResult result = iv.Validate(i);
            if (result.IsValid)
            {
                _ımageService.Update(i);
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
