using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Command.Update;
using Teknoroma.Application.Features.AppUsers.Models;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class AccountController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			await CheckJwtBearer();

			var getAppUserId = await ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}");

			if (getAppUserId == null) return RedirectToAction("Index", "Home");

			var getAppUser = await ApiService.HttpClient.GetFromJsonAsync<GetByIdAppUserQueryResponse>($"user/getbyid/{getAppUserId.ID}");

			if (getAppUser == null) return RedirectToAction("Index", "Home");

			AppUserViewModel appUserViewModel = Mapper.Map<AppUserViewModel>(getAppUser);

			return View(appUserViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid) return View(model);

			UpdateAppUserCommandRequest updateAppUserCommandRequest = Mapper.Map<UpdateAppUserCommandRequest>(model);

			HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("user/update", updateAppUserCommandRequest);

			if (!response.IsSuccessStatusCode)
			{
				await HandleErrorResponse(response);
				return View(model);
			}

			return RedirectToAction("Index", "Account");
		}
	}
}
