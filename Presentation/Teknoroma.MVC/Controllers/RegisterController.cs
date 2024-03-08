using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Command.Create;
using Teknoroma.Application.Features.AppUsers.Models;
using Teknoroma.MVC.Areas.Admin.Controllers;

namespace Teknoroma.MVC.Controllers
{
	public class RegisterController : BaseController
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAppUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                 
                return View(model);
            }

            CreateAppUserCommandRequest createAppUserCommandRequest = Mapper.Map<CreateAppUserCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("user/create", createAppUserCommandRequest);

            if (response.IsSuccessStatusCode) return RedirectToAction("Index", "Login");

            await HandleErrorResponse(response);

            return View(model);
        } 
    }
}
