//using DataAccessLayer.Contexts;
using DataLayer.DataBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        ProjectContext c = new ProjectContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = c.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();

            ViewBag.announcementTrue = c.Newses.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Newses.Where(x => x.Status == false).Count();

            ViewBag.fullStack = c.Teams.Where(x => x.Title == "FullStack Developer").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.ciftci = c.Teams.Where(x => x.Title == "Çiftçi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.tasarimci = c.Teams.Where(x => x.Title == "Tasarımcı").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.mudur = c.Teams.Where(x => x.Title == "Müdür").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}
