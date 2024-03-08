using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Teknoroma.Application.Features.AppUsers.Commands.Login;
using Teknoroma.Application.Features.AppUsers.Models;
using Teknoroma.Domain.Entities;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Areas.Admin.Controllers;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(IMapper mapper, IApiService apiService,SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
           _apiService = apiService;
			_signInManager = signInManager;
			_userManager = userManager;
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
            if (!ModelState.IsValid) return View(model);

            LoginAppUserCommandRequest loginAppUserCommandRequest = _mapper.Map<LoginAppUserCommandRequest>(model);

            HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("user/login", loginAppUserCommandRequest);

            if(!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                return View(model);
            }

            var appUser = await _userManager.FindByNameAsync(model.UserName);

            await _signInManager.PasswordSignInAsync(appUser, model.Password,false,false);

            
            string getToken = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenViewModel>(getToken);
            Response.Cookies.Append("LoginJWT", token.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            ApiService.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            return RedirectToAction("Index", "Home");     
        }

        
    }
}
