using Microsoft.AspNetCore.Mvc;

namespace OopProject.ViewComponents
{
	public class _HeadPartial : ViewComponent
	{
		public IViewComponentResult Invoke() 
		{ 
			return View();
		}
	}
}
