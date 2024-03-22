using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Departments.Command.Create;
using Teknoroma.Application.Features.Departments.Command.Update;
using Teknoroma.Application.Features.Departments.Models;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Application.Features.Departments.Queries.GetListSelectIdAndName;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class DepartmentController : BaseController
    {
        
        [HttpGet]
		[Authorize(Roles = "Departman Ekle")]
		public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
		[Authorize(Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
		public async Task<IActionResult> Create(CreateDepartmentViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
				return View(model);

			CreateDepartmentCommandRequest createDepartmentDTO = Mapper.Map<CreateDepartmentCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("department/create", createDepartmentDTO);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                return View(model);
            }

            return View();

        }
        [HttpGet]
		[Authorize(Roles = "Departman Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await DepartmentViewBag();

            if (id == null) return View();

            var response = await GetByDepartmentId((Guid)id);

            if (response == null) return View();

            DepartmentViewModel departmentViewModel = Mapper.Map<DepartmentViewModel>(response);

            return View(departmentViewModel);
        }
        [HttpPost]
		[Authorize(Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
		public async Task<IActionResult> Update(DepartmentViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await DepartmentViewBag();
                return View(model);
            }
            UpdateDepartmentCommandRequest updateDepartment = Mapper.Map<UpdateDepartmentCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("department/update", updateDepartment);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                await DepartmentViewBag();
                return View(model);
            }

            return RedirectToAction("Update", model.ID);
        }
        [HttpGet]
		[Authorize(Roles = "Departman Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"department/delete/{id}");

            return RedirectToAction("DepartmentList", "Department");
        }
        
        [HttpGet]
		[Authorize(Roles = "Departman Listele")]
		public async Task<IActionResult> DepartmentList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllDepartmentQueryResponse>>("department/getall");

            if (response.Count <= 0) return View();

            List<DepartmentViewModel> departmentViewModels = Mapper.Map<List<DepartmentViewModel>>(response);

            return View(departmentViewModels);
        }

        [HttpGet]
		[Authorize(Roles = "Departman Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await DepartmentViewBag();

            if (id == null) return View();

            var response = await GetByDepartmentId((Guid)id);

            DepartmentViewModel departmentViewModel = Mapper.Map<DepartmentViewModel>(response);

            return View(departmentViewModel);
        }

        private async Task<GetByIdDepartmentQueryResponse> GetByDepartmentId(Guid id)
        {
          var result= await ApiService.HttpClient.GetFromJsonAsync<GetByIdDepartmentQueryResponse>($"department/GetById/{id}");
          return result;
        }

        private async Task DepartmentViewBag()
        {
            var getDepartmentList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameDepartmentResponse>>("department/GetAllSelectIdAndName");

            ViewBag.DepartmentList = getDepartmentList;
        }
    }
}
