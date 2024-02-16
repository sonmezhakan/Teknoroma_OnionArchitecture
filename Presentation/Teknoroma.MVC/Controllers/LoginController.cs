using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.DTOs.AccountDTOs;
using Teknoroma.Application.ViewModel;
using Teknoroma.Domain.Entities;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IApiService _apiService;

        public LoginController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IApiService apiService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
           _apiService = apiService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Tüm Alanları Doldurunuz!");

            LoginDTO loginDTO = _mapper.Map<LoginDTO>(model);

            HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("user/login", loginDTO);

            if(!response.IsSuccessStatusCode) return View(model);

            var appUser = await _userManager.FindByNameAsync(model.UserName);
            var result = await _signInManager.PasswordSignInAsync(appUser, loginDTO.Password, false, false);

            Response.Cookies.Append("LoginJWT", response.Content.ReadAsStringAsync().Result, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return RedirectToAction("Index", "Home");

            
        }
    }
}
