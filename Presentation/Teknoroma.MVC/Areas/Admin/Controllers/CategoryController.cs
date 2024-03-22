using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Categories.Commands.Create;
using Teknoroma.Application.Features.Categories.Commands.Update;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Categories.Queries.GetById;
using Teknoroma.Application.Features.Categories.Queries.GetCategoryEarningReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySupplyReport;
using Teknoroma.Application.Features.Categories.Queries.GetList;
using Teknoroma.Application.Features.Categories.Queries.GetListSelectIdAndName;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize]
    public class CategoryController : BaseController
    {

        [HttpGet]
		[Authorize(Roles = "Kategori Ekle")]
		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[Authorize(Roles = "Kategori Ekle")]
		public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            await CheckJwtBearer();

            if (!ModelState.IsValid)
				return View(model);

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
		[Authorize(Roles = "Kategori Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await CategoryViewBag();

            if (id == null) return View();

            var response = await GetByCategoryId((Guid)id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(response);

            return View(categoryViewModel);
        }

        [HttpPost]
		[Authorize(Roles = "Kategori Güncelle")]
		public async Task<IActionResult> Update(CategoryViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await CategoryViewBag();
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
		[Authorize(Roles = "Kategori Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"category/Delete/{id}");

            return RedirectToAction("CategoryList","Category");
        }

        [HttpGet]
		[Authorize(Roles = "Kategori Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await CategoryViewBag();

            if (id == null) return View();

            var response = await GetByCategoryId((Guid)id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(response);

            return View(categoryViewModel);
        }

        [HttpGet]
		[Authorize(Roles = "Kategori Listele")]
		public async Task<IActionResult> CategoryList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllCategoryQueryResponse>>("category/getall");

            if (response == null) return View();

            List<CategoryViewModel> categoryViewModels = Mapper.Map<List<CategoryViewModel>>(response);

            return View(categoryViewModels);
        }
        [HttpGet]
		[Authorize(Roles = "Kategori Raporları")]
		public async Task<IActionResult> CategoryReport(DateTime? startDate, DateTime? endDate)
        {
            await CheckJwtBearer();
            if (startDate == null || endDate == null)
            {
                startDate = DateTime.MinValue;
                endDate = DateTime.MaxValue;
            }
            else
            {
                endDate = endDate.Value.AddDays(1);
            }

            var categorySellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetCategorySellingReportQueryResponse>>($"category/CategorySellingReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<CategorySellingReportViewModel> categorySellingReportViewModels = Mapper.Map<List<CategorySellingReportViewModel>>(categorySellingReports);

            var categoryEarningReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetCategoryEarningReportQueryResponse>>($"category/CategoryEarningReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<CategoryEarningReportViewModel> categoryEarningReportsViewModels = Mapper.Map<List<CategoryEarningReportViewModel>>(categoryEarningReports);

            var categorySupplyReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetCategorySupplyReportQueryResponse>>($"category/CategorySupplyReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<CategorySupplyReportViewModel> categorySupplyReportViewModels = Mapper.Map<List<CategorySupplyReportViewModel>>(categorySupplyReports);

            CategoryReportViewModel categoryReportViewModel = new CategoryReportViewModel
            {
                CategorySellingReportViewModels = categorySellingReportViewModels,
                CategoryEarningReportViewModels = categoryEarningReportsViewModels,
                CategorySupplyReportViewModels = categorySupplyReportViewModels
            };

            return View(categoryReportViewModel);
        }

        private async Task<GetByIdCategoryQueryResponse> GetByCategoryId(Guid id)
        {
           var result = await ApiService.HttpClient.GetFromJsonAsync<GetByIdCategoryQueryResponse>($"category/GetById/{id}");
            return result;
        }

        private async Task CategoryViewBag()
        {
            var getCategoryList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameCategoryQueryResponse>>("category/GetAllSelectIdAndName");

			ViewBag.CategoryList = getCategoryList;
		}
    }
}
