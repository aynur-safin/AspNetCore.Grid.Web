using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Grid.Web.Context;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Installation()
        {
            return View();
        }
    }
}
