using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Departments.Command.Create;
using Teknoroma.Application.Features.Departments.Command.Update;
using Teknoroma.Application.Features.Departments.Models;
using Teknoroma.Application.Features.Departments.Queries.GetById;
using Teknoroma.Application.Features.Departments.Queries.GetList;
using Teknoroma.Infrastructure.WebApiService;

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

                if (response.IsSuccessStatusCode) return View();

                ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

                return View(model);
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

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdDepartmentCommandResponse>($"department/GetById/{id}");

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

                if(response.IsSuccessStatusCode) return RedirectToAction("Update", new { id = model.ID });

                ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);
                await DepartmentViewBag();
                return View(model.ID);
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
            HttpResponseMessage response = await _apiService.HttpClient.DeleteAsync($"department/delete/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction("DepartmentList", "Department");

            ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

            return RedirectToAction("DepartmentList", "Department");
        }
        
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllDepartmentCommandResponse>>("department/getall");

            if (response.Count <= 0) return View();

            List<DepartmentViewModel> departmentViewModels = _mapper.Map<List<DepartmentViewModel>>(response);

            return View(departmentViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await DepartmentViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdDepartmentCommandResponse>($"department/getbyid/{id}");

            DepartmentViewModel departmentViewModel = _mapper.Map<DepartmentViewModel>(response);

            return View(departmentViewModel);
        }

        private async Task DepartmentViewBag()
        {
            var getDepartmentList = _apiService.HttpClient.GetFromJsonAsync<List<GetAllDepartmentCommandResponse>>("department/getall").Result.Select(x => new GetAllDepartmentCommandResponse
			{
                ID = x.ID,
                DepartmentName = x.DepartmentName
            }).ToList();

            ViewBag.DepartmentList = getDepartmentList;
        }
    }
}
