using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Domain.Entities;

namespace Teknoroma.MVC.Controllers
{
    public class SignOutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignOutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
