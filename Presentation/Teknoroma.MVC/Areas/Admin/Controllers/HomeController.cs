using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.DTOs;
using Teknoroma.Application.ViewModel;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    /*[Authorize(Roles = "Admin")]*/
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}