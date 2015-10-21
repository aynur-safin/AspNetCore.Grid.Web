using Microsoft.AspNet.Mvc;
using NonFactors.Mvc.Grid.Web.Context;
using NonFactors.Mvc.Grid.Web.Models;
using System.Linq;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class GridController : Controller
    {
        [HttpGet]
        public ActionResult RowProcessing()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Ajax()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GridPartial()
        {
            return PartialView("_AjaxGrid", PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult MultiFiltering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Filtering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Sorting()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult RowStyling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Styling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult EmptyText()
        {
            return View(Enumerable.Empty<PersonModel>());
        }

        [HttpGet]
        public ActionResult Multiple()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Paging()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Localization()
        {
            return View(PeopleRepository.GetPeople());
        }
    }
}