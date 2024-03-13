using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Brands.Command.Create;
using Teknoroma.Application.Features.Brands.Command.Update;
using Teknoroma.Application.Features.Brands.Models;
using Teknoroma.Application.Features.Brands.Quries.GetBrandEarningReport;
using Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport;
using Teknoroma.Application.Features.Brands.Quries.GetById;
using Teknoroma.Application.Features.Brands.Quries.GetList;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class BrandController : BaseController
	{
		[HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Create(CreateBrandViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
			{
                 
                return View(model);
            }

            CreateBrandCommandRequest createBrand = Mapper.Map<CreateBrandCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("brand/create", createBrand);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);

                return View(model);
            }

            return RedirectToAction("Create", "Brand");
        }

		[HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Update(Guid? id)
		{
            await CheckJwtBearer();
            await BrandViewBag();

            if (id == null) return View();

            var response = await GetByBrandId((Guid)id);

            BrandViewModel brandViewModel = Mapper.Map<BrandViewModel>(response);

            return View(brandViewModel);
		}

		[HttpPost]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Update(BrandViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
			{
                await BrandViewBag();
                 
                return View(model);
            }

            UpdateBrandCommandRequest updateBrand = Mapper.Map<UpdateBrandCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("brand/update", updateBrand);

            if (!response.IsSuccessStatusCode)
            {
				await HandleErrorResponse(response);
                await BrandViewBag();
                return View(model);
            }

            return RedirectToAction("Update", model.ID);
        }

        [HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Delete(Guid id)
		{
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"brand/delete/{id}");

			return RedirectToAction("BrandList", "Brand");
        }

		[HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Detail(Guid? id)
		{
            await CheckJwtBearer();
            await BrandViewBag();

			if (id == null) return View();

			var response = await GetByBrandId((Guid)id);


            BrandViewModel brandViewModel = Mapper.Map<BrandViewModel>(response);

			return View(brandViewModel);
		}

		[HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> BrandList()
		{
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllBrandCommandResponse>>("brand/getall");

			if (response == null) return View();

			List<BrandViewModel> brandViewModels = Mapper.Map<List<BrandViewModel>>(response);

			return View(brandViewModels);
		}
		[HttpGet]
		[Authorize(Roles = "Şube Müdürü")]
		public async Task<IActionResult> BrandReport(DateTime? startDate,DateTime? endDate)
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
            var brandSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBrandSellingReportQueryResponse>>($"brand/BrandSellingReport/{startDate?.ToString("yyyy.MM.dd")}/{endDate?.ToString("yyyy.MM.dd")}");

			List<BrandSellingReportViewModel> brandSellingReportViewModels = Mapper.Map<List<BrandSellingReportViewModel>>(brandSellingReports);

			var brandEarningReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBrandEarningReportQueryResponse>>($"brand/BrandEarningReport/{startDate?.ToString("yyyy.MM.dd")}/{endDate?.ToString("yyyy.MM.dd")}");

			List<BrandEarningReportViewModel> brandEarningReportViewModels = Mapper.Map<List<BrandEarningReportViewModel>>(brandEarningReports);

			BrandReportViewModel brandReportViewModel = new BrandReportViewModel
			{
				BrandEarningReportViewModels = brandEarningReportViewModels,
				BrandSellingReportViewModels = brandSellingReportViewModels
			};

			return View(brandReportViewModel);
		}


		private async Task<GetByIdBrandQueryResponse> GetByBrandId(Guid id)
		{
			return await ApiService.HttpClient.GetFromJsonAsync<GetByIdBrandQueryResponse>($"brand/getbyid/{id}");
        }

        private async Task BrandViewBag()
        {
            var getBrandList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllBrandCommandResponse>>("brand/getall").Result.Select(x => new GetAllBrandCommandResponse
			{
				BrandName = x.BrandName,
				ID = x.ID
			}).ToList();

			ViewBag.BrandList = getBrandList;
		}
    }
}
