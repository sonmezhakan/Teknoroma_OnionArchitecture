using Microsoft.AspNetCore.Mvc;

namespace Teknoroma.MVC.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
