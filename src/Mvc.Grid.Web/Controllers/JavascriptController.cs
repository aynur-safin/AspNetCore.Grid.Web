using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;
using System;
using System.Threading;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class JavascriptController : Controller
    {
        [HttpGet]
        public ActionResult Api()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult RowClicked()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Reload()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public ActionResult ReloadGrid(String name)
        {
            return PartialView("_ReloadGrid", PeopleRepository.GetPeople(name));
        }

        [HttpGet]
        public ActionResult RequestType()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReloadEvents()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReloadEventsGrid()
        {
            Thread.Sleep(500);

            return PartialView("_ReloadGrid", PeopleRepository.GetPeople());
        }
    }
}
