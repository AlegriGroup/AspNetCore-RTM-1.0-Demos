using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Mvc_TagHelper_CoreFx.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
