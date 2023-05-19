using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OopProject.ViewComponents
{
	public class _NewsPartial:ViewComponent
	{
		private readonly INewsService _newsService;

		public _NewsPartial(INewsService newsService)
		{
			_newsService = newsService;
		}

		public IViewComponentResult Invoke()
		{ 
			var values = _newsService.GetListAll();
			return View(values);
		}
	}
}
