using DataLayer.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace OopProject.ViewComponents
{
    public class _MapPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ProjectContext context = new ProjectContext();
            var value = context.Addresses.Select(x => x.MapInfo).FirstOrDefault();
            ViewBag.v = value;
            return View();
        }
    }
}
