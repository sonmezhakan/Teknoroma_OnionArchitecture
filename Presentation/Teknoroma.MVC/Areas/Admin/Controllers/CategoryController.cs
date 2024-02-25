using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetList;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : BaseController
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if(!ModelState.IsValid)
            {
                await ErrorResponse();
                return View(model);
            }
            CreateCategoryCommandRequest createCategoryCommandRequest = Mapper.Map<CreateCategoryCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("category/create", createCategoryCommandRequest);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {   
            await CategoryViewBag();

            if (id == null) return View();

            var response = await GetByCategoryId((Guid)id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(response);

            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await CategoryViewBag();
                await ErrorResponse();
                return View(model);
            }
            UpdateCategoryCommandRequest updateCategoryCommandRequest = Mapper.Map<UpdateCategoryCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("category/Update", updateCategoryCommandRequest);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                await CategoryViewBag();
                return View(model);
            }

            return RedirectToAction("Update", model.ID);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await ApiService.HttpClient.DeleteAsync($"category/Delete/{id}");

            return RedirectToAction("CategoryList","Category");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CategoryViewBag();

            if (id == null) return View();

            var response = await GetByCategoryId((Guid)id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(response);

            return View(categoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall");

            if (response == null) return View();

            List<CategoryViewModel> categoryViewModels = Mapper.Map<List<CategoryViewModel>>(response);

            return View(categoryViewModels);
        }

        private async Task<GetByIdCategoryQueryResponse> GetByCategoryId(Guid id)
        {
           return await ApiService.HttpClient.GetFromJsonAsync<GetByIdCategoryQueryResponse>($"category/GetById/{id}");
        }

        private async Task CategoryViewBag()
        {
            var getCategoryList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall").Result.Select(x => new GetAllCategoryQueryResponse
            {
                CategoryName = x.CategoryName,
                ID = x.ID
            }).ToList();

			ViewBag.CategoryList = getCategoryList;
		}
    }
}
