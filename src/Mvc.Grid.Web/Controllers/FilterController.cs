using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class FilterController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Unregister()
        {
            return View(PeopleRepository.GetPeople());
        }
    }
}