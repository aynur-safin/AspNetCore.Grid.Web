using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class ColumnController : Controller
    {
        [HttpGet]
        public ViewResult RenderingValue()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult MultiFiltering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Filtering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult FilterOptions()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult CustomFilter()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult InitialSort()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult FirstSort()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Sorting()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Encoding()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Formatting()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Styling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Title()
        {
            return View(PeopleRepository.GetPeople());
        }
    }
}