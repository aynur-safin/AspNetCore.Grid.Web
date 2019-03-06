using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class PagerController : Controller
    {
        [HttpGet]
        public ViewResult PagesToDisplay()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult CurrentPage()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult RowsPerPage()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult PageSizes()
        {
            return View(PeopleRepository.GetPeople());
        }
    }
}
