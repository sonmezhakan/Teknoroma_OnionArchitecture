using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetList;
using Teknoroma.Application.Features.AppUsers.Command.Create;
using Teknoroma.Application.Features.AppUsers.Command.Update;
using Teknoroma.Application.Features.AppUsers.Models;
using Teknoroma.Application.Features.AppUsers.Queries.GetById;
using Teknoroma.Application.Features.AppUsers.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AppUserController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await AppUserRoleViewBag();
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await AppUserRoleViewBag();
                 
                return View(model);
            }
            CreateAppUserCommandRequest createAppUserCommandRequest = Mapper.Map<CreateAppUserCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("user/create", createAppUserCommandRequest);

            if (response.IsSuccessStatusCode) return RedirectToAction("Create", "AppUser");

            await HandleErrorResponse(response);
            await AppUserRoleViewBag();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await CheckJwtBearer();
            await AppUserViewBag();
			await AppUserRoleViewBag();

			if (id == null) return View();

            var response = await GetByAppUserId((Guid)id);

            if (response == null) return null;

            AppUserViewModel appUserViewModel = Mapper.Map<AppUserViewModel>(response);

            return View(appUserViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUserViewModel model)
        {
            await CheckJwtBearer();
            await AppUserViewBag();
            await AppUserRoleViewBag();
            if (!ModelState.IsValid)
            {
                 
                return View(model);
            }

            UpdateAppUserCommandRequest updateAppUserCommandRequest = Mapper.Map<UpdateAppUserCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("user/update", updateAppUserCommandRequest);

            if (response.IsSuccessStatusCode) return RedirectToAction("Update", model.ID);

            await HandleErrorResponse(response);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await AppUserViewBag();
            await AppUserRoleViewBag();

            if (id == null) return View();

            var response = await GetByAppUserId((Guid)id);

            if (response == null) return null;

            AppUserViewModel appUserViewModel = Mapper.Map<AppUserViewModel>(response);

            return View(appUserViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllAppUserQueryResponse>>("user/getall");

            List<AppUserViewModel> appUserViewModels = Mapper.Map<List<AppUserViewModel>>(response);

            return View(appUserViewModels);
        }

        private async Task<GetByIdAppUserQueryResponse> GetByAppUserId(Guid id)
        {
            return await ApiService.HttpClient.GetFromJsonAsync<GetByIdAppUserQueryResponse>($"user/getbyid/{id}");
        }
        private async Task AppUserViewBag()
        {
            var getAppUser = ApiService.HttpClient.GetFromJsonAsync<List<GetAllAppUserQueryResponse>>("user/getall")
                .Result.Select(x=> new GetAllAppUserQueryResponse
                {
                    ID = x.ID,
                    UserName = x.UserName
                });
            ViewBag.AppUserList = getAppUser;
        }
        private async Task AppUserRoleViewBag()
        {
            var getAppUserRole = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllAppUserRoleQueryResponse>>("role/getall");

            ViewBag.AppUserRoleList = getAppUserRole;
        }
    }
}
