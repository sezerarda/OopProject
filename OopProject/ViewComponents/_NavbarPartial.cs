using Microsoft.AspNetCore.Mvc;

namespace OopProject.ViewComponents
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
