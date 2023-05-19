using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OopProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            var values = _newsService.GetListAll();
            return View(values);
        }

        public IActionResult AddNews()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddNews(News news)
        {
            news.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            news.Status = false;
            _newsService.Insert(news);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNews(int id)
        {
            var values = _newsService.GetById(id);
            _newsService.Delete(values);
            return RedirectToAction("Index");
        }

        public IActionResult EditNews(int id)
        {
            var values = _newsService.GetById(id);
            
            return View(values);
        }
        [HttpPost]

        public IActionResult EditNews(News news)
        {
            _newsService.Update(news);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusTrue(int id)
        {
            _newsService.NewsStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusFalse(int id)
        {
            _newsService.NewsStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
