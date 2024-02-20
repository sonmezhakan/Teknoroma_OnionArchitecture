using Microsoft.AspNetCore.Mvc;

namespace Teknoroma.MVC.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
