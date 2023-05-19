using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OopProject.Models;

namespace OopProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public IActionResult Index()
        {
            var value = _serviceService.GetListAll();

            return View(value);
        }

        public IActionResult AddService()
        {

            return View(new ServiceAddViewModel());
        }
        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {

            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image

                });
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public IActionResult DeleteService(int id)
        {

            var value = _serviceService.GetById(id);
            _serviceService.Delete(value);
            return RedirectToAction("Index");
        }
        public IActionResult EditService(int id)
        {

            var value = _serviceService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditService(Service s)
        {

            _serviceService.Update(s);
            return RedirectToAction("Index");
        }
        public IActionResult Deneme()
        { 
            return View();
        }
    }
}
