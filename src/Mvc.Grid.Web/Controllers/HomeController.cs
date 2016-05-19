using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Installation()
        {
            return View();
        }
    }
}