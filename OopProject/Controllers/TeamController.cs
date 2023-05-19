using BusinessLayer.Abstract;
using BusinessLayer.Validation_Rules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace OopProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }

        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team t)
        {
            TeamValidator tv = new TeamValidator();
            ValidationResult result = tv.Validate(t);
            if (result.IsValid)
            {
                _teamService.Insert(t);
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
        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.GetById(id);
            _teamService.Delete(value);
            return RedirectToAction("Index");
        }
        public IActionResult EditTeam(int id)
        {
            var value = _teamService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditTeam(Team team)
        {

            TeamValidator tv = new TeamValidator();
            ValidationResult result = tv.Validate(team);
            if (result.IsValid)
            {
                _teamService.Update(team);
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
