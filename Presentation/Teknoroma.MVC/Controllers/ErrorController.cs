using Microsoft.AspNetCore.Mvc;

namespace Teknoroma.MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Forbidden()
        {
           
            return View();
        }
		[HttpGet]
		public IActionResult NotFound()
		{

			return View();
		}
		[HttpGet]
		public IActionResult InternalServer()
		{

			return View();
		}
	}
}
