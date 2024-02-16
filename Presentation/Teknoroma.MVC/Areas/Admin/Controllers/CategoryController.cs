using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.DTO;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetList;
using Teknoroma.Infrastructure.WebApiService;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApiService _apiService;

        public CategoryController(IMapper mapper, IApiService apiService)
        {
            _mapper = mapper;
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                CreateCategoryCommandRequest createCategoryCommandRequest = _mapper.Map<CreateCategoryCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("category/create", createCategoryCommandRequest);

                if (!response.IsSuccessStatusCode) return View();

                ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

                return View(model);
            }
            ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {   
            await CategoryViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdCategoryQueryResponse>($"category/GetById/{id}");

            CategoryViewModel categoryViewModel = _mapper.Map<CategoryViewModel>(response);

            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel categoryViewModel)
        {
            if(ModelState.IsValid)
            {
                UpdateCategoryCommandRequest updateCategoryCommandRequest = _mapper.Map<UpdateCategoryCommandRequest>(categoryViewModel);

                HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("category/Update", updateCategoryCommandRequest);

                if (response.IsSuccessStatusCode) return RedirectToAction("Update", new { id = categoryViewModel.ID });

                ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

                return View(categoryViewModel.ID);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

                return View(categoryViewModel.ID);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _apiService.HttpClient.DeleteAsync($"category/Delete/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction("CategoryList", "Category");

            ModelState.AddModelError(string.Empty, response.Content.ReadAsStringAsync().Result);

            return RedirectToAction("CategoryList","Category");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CategoryViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdCategoryQueryResponse>($"category/GetById/{id}");

            CategoryViewModel categoryViewModel = _mapper.Map<CategoryViewModel>(response);

            return View(categoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall");

            if (response == null) return View();

            List<CategoryViewModel> categoryViewModels = _mapper.Map<List<CategoryViewModel>>(response);

            return View(categoryViewModels);
        }

        public async Task CategoryViewBag()
        {
            var getCategoryList = _apiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall").Result.Select(x => new GetAllCategoryQueryResponse
            {
                CategoryName = x.CategoryName,
                ID = x.ID
            }).ToList();

			ViewBag.CategoryList = getCategoryList;
		}
    }
}
