using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUserRoles.Command.Create;
using Teknoroma.Application.Features.AppUserRoles.Command.Update;
using Teknoroma.Application.Features.AppUserRoles.Models;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetById;
using Teknoroma.Application.Features.AppUserRoles.Queries.GetList;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AppUserRoleController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserRoleViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await ErrorResponse();
                return View(model);
            }
            CreateAppUserRoleCommandRequest createAppUserRoleCommandRequest = Mapper.Map<CreateAppUserRoleCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("role/create", createAppUserRoleCommandRequest);

            if (response.IsSuccessStatusCode) return RedirectToAction("Create", "AppUserRole");

            await HandleErrorResponse(response);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await AppUserRoleViewbag();

            if (id == null) return View();

            var response = await GetByRoleId((Guid)id);

            if (response == null) return View();

            AppUserRoleViewModel appUserRoleViewModel = Mapper.Map<AppUserRoleViewModel>(response);

            return View(appUserRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUserRoleViewModel model)
        {
            await CheckJwtBearer();
            await AppUserRoleViewbag();
            if (!ModelState.IsValid)
            {
                await AppUserRoleViewbag();
                await ErrorResponse();
                return View(model);
            }
            UpdateAppUserRoleCommandRequest updateAppUserRoleCommandRequest = Mapper.Map<UpdateAppUserRoleCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("role/update", updateAppUserRoleCommandRequest);

            if (response.IsSuccessStatusCode) return View(model.ID);

            await HandleErrorResponse(response);
            await AppUserRoleViewbag();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"role/delete/{id}");

            return RedirectToAction("AppUserRoleList", "AppUserRole");
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await AppUserRoleViewbag();

            if (id == null) return View();

            var response = await GetByRoleId((Guid)id);

            if (response == null) return View();

            AppUserRoleViewModel appUserRoleViewModel = Mapper.Map<AppUserRoleViewModel>(response);

            return View(appUserRoleViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AppUserRoleList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllAppUserRoleQueryResponse>>("role/getall");

            if (response == null) return View();

            List<AppUserRoleViewModel> appUserRoleViewModels = Mapper.Map<List<AppUserRoleViewModel>>(response);

            return View(appUserRoleViewModels);
        }

        private async Task<GetByIdAppUserRoleQueryResponse> GetByRoleId(Guid id)
        {
           return await ApiService.HttpClient.GetFromJsonAsync<GetByIdAppUserRoleQueryResponse>($"role/getbyid/{id}");
        }
        private async Task AppUserRoleViewbag()
        {
            var appUserRoles = ApiService.HttpClient.GetFromJsonAsync<List<GetAllAppUserRoleQueryResponse>>("role/getall").Result.Select(x=> new GetAllAppUserRoleQueryResponse
            {
                ID = x.ID,
                Name = x.Name
            });

            ViewBag.AppUserRoleList = appUserRoles;
        }
    }
}
