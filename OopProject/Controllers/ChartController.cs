using Microsoft.AspNetCore.Mvc;
using OopProject.Models;

namespace OopProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            List<ProductClass> products = new List<ProductClass>();
            products.Add(new ProductClass
            {
                productname = "Buğday",
                productvalue = 150
            });

            products.Add(new ProductClass
            {
                productname = "Mercimek",
                productvalue = 300
            });

            products.Add(new ProductClass
            {
                productname = "Pirinç",
                productvalue = 430
            });

            products.Add(new ProductClass
            {
                productname = "Domates",
                productvalue = 456
            });
            return Json(new { jsonlist = products });
        }
    }
}
