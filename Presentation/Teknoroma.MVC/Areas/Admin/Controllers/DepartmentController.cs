using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Departments.Command.Create;
using Teknoroma.Application.Features.Departments.Command.Update;
using Teknoroma.Application.Features.Departments.Models;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public DepartmentController(IMapper mapper,IApiService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentViewModel model)
        {
            if(ModelState.IsValid)
            {
                CreateDepartmentCommandRequest createDepartmentDTO = _mapper.Map<CreateDepartmentCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("department/create", createDepartmentDTO);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					return View(model);
				}

				return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

                return View(model);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            await DepartmentViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdDepartmentQueryResponse>($"department/GetById/{id}");

            if(response == null) return View();

            DepartmentViewModel departmentViewModel = _mapper.Map<DepartmentViewModel>(response);

            return View(departmentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentViewModel model)
        {
            if(ModelState.IsValid)
            {
                UpdateDepartmentCommandRequest updateDepartment = _mapper.Map<UpdateDepartmentCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("department/update", updateDepartment);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					await DepartmentViewBag();

					return View(model);
				}

				return RedirectToAction("Update", model.ID);
			}
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

                await DepartmentViewBag();

                return View(model.ID);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _apiService.HttpClient.DeleteAsync($"department/delete/{id}");

            return RedirectToAction("DepartmentList", "Department");
        }
        
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllDepartmentQueryResponse>>("department/getall");

            if (response.Count <= 0) return View();

            List<DepartmentViewModel> departmentViewModels = _mapper.Map<List<DepartmentViewModel>>(response);

            return View(departmentViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await DepartmentViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdDepartmentQueryResponse>($"department/getbyid/{id}");

            DepartmentViewModel departmentViewModel = _mapper.Map<DepartmentViewModel>(response);

            return View(departmentViewModel);
        }

        private async Task DepartmentViewBag()
        {
            var getDepartmentList = _apiService.HttpClient.GetFromJsonAsync<List<GetAllDepartmentQueryResponse>>("department/getall").Result.Select(x => new GetAllDepartmentQueryResponse
			{
                ID = x.ID,
                DepartmentName = x.DepartmentName
            }).ToList();

            ViewBag.DepartmentList = getDepartmentList;
        }
    }
}
