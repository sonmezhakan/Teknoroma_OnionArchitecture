using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Teknoroma.Application.DTOs.AccountDTOs;
using Teknoroma.Application.ViewModel;
using Teknoroma.Domain.Entities;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApiService _webApiService;

        public RegisterController(IMapper mapper,IApiService webApiService)
        {
            _mapper = mapper;
            _webApiService = webApiService;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View();

            RegisterDTO registerDTO = _mapper.Map<RegisterDTO>(model);

            HttpResponseMessage response = await _webApiService.HttpClient.PostAsJsonAsync("user/register", registerDTO);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index","Home");

            return View(model);
        }

        
    }
}
