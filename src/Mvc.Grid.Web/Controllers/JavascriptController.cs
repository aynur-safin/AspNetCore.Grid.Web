using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;
using System;
using System.Threading;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class JavascriptController : Controller
    {
        [HttpGet]
        public ViewResult Api()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult RowClicked()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Reload()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        [HttpPost]
        public PartialViewResult ReloadGrid(String name)
        {
            return PartialView("_ReloadGrid", PeopleRepository.GetPeople(name));
        }

        [HttpGet]
        public ViewResult RequestType()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult ReloadEvents()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public PartialViewResult ReloadEventsGrid()
        {
            Thread.Sleep(2000);

            return PartialView("_ReloadEventsGrid", PeopleRepository.GetPeople());
        }
    }
}
