using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Domain.Entities;

namespace Teknoroma.MVC.Controllers
{
    [Authorize]
	public class SignOutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignOutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete("LoginJWT");
            return RedirectToAction("Index", "Home");
        }
    }
}
