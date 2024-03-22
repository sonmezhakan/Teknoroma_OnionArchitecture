using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.Branches.Command.Update;
using Teknoroma.Application.Features.Branches.Models;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetBranchEarningReport;
using Teknoroma.Application.Features.Branches.Queries.GetBranchSellingReport;
using Teknoroma.Application.Features.Branches.Queries.GetById;
using Teknoroma.Application.Features.Branches.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Stocks.Models;
using Teknoroma.Application.Features.Stocks.Queries.GetList;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class BranchController : BaseController
	{
        [HttpGet]
		[Authorize(Roles = "Şube Ekle")]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		[Authorize(Roles = "Şube Ekle")]
		public async Task<IActionResult> Create(CreateBranchViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
				return View(model);

			CreateBranchCommandRequest createBranch = Mapper.Map<CreateBranchCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("branch/create", createBranch);

            if (!response.IsSuccessStatusCode)
            {
				await HandleErrorResponse(response);
                return View(model);
            }

            return RedirectToAction("Create", "Branch");
        }

		[HttpGet]
		[Authorize(Roles = "Şube Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
		{
            await CheckJwtBearer();
            await BranchViewBag();

			if (id == null) return View();

			var response = await GetByBranchId((Guid)id);

            if (response == null) return View();

			BranchViewModel branchViewModel = Mapper.Map<BranchViewModel>(response);

			return View(branchViewModel);
		}

		[HttpPost]
		[Authorize(Roles = "Şube Güncelle")]
		public async Task<IActionResult> Update(BranchViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await BranchViewBag();
                return View(model);
            }

            UpdateBranchCommandRequest updateBranch = Mapper.Map<UpdateBranchCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("branch/update", updateBranch);

            if (!response.IsSuccessStatusCode)
            {
				await HandleErrorResponse(response);
                await BranchViewBag();
                return View(model);
            }

            return RedirectToAction("Update", model.ID);
        }

		[HttpGet]
		[Authorize(Roles = "Şube Sil")]
		public async Task<IActionResult> Delete(Guid id)
		{
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"branch/delete/{id}");

			return RedirectToAction("BranchList", "Branch");
		}

		[HttpGet]
		[Authorize(Roles = "Şube Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
		{
            await CheckJwtBearer();
            await BranchViewBag();

			if (id == null) return View();

			var response = await GetByBranchId((Guid)id);

            if (response == null) return View();

			await StockViewBag(response.ID);

            BranchViewModel branchViewModel = Mapper.Map<BranchViewModel>(response);

			return View(branchViewModel);
		}

		[HttpGet]
		[Authorize(Roles = "Şube Listele")]
		public async Task<IActionResult> BranchList()
		{
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllBranchQueryResponse>>("branch/getall");

			if (response == null) return View();

			List<BranchListViewModel> branchViewModels = Mapper.Map<List<BranchListViewModel>>(response);

			return View(branchViewModels);
		}
		[HttpGet]
		[Authorize(Roles = "Şube Raporları")]
		public async Task<IActionResult> BranchReport(DateTime? startDate,DateTime? endDate)
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
            var branchSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBranchSellingReportQueryResponse>>($"branch/branchsellingreport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<BranchSellingReportViewModel> branchSellingReportViewModels = Mapper.Map<List<BranchSellingReportViewModel>>(branchSellingReports);

			var branchEarningReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBranchEarningReportQueryResponse>>($"branch/branchEarningReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<BranchEarningReportViewModel> branchEarningReportViewModels = Mapper.Map<List<BranchEarningReportViewModel>>(branchEarningReports);

			BranchReportViewModel branchReportViewModel = new BranchReportViewModel
			{
				BranchEarningReportViewModels = branchEarningReportViewModels,
				BranchSellingReportViewModels = branchSellingReportViewModels
			};

			return View(branchReportViewModel);
		}

		private async Task<GetByIdBranchQueryResponse> GetByBranchId(Guid id)
		{
			return await ApiService.HttpClient.GetFromJsonAsync<GetByIdBranchQueryResponse>($"branch/getbyid/{id}");
        }

		private async Task BranchViewBag()
		{
			var getBranchList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameBranchQueryResponse>>("branch/GetAllSelectIdAndName");

			ViewBag.BranchList = getBranchList;

		}
		private async Task StockViewBag(Guid id)
		{
			var getstockList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockQueryResponse>>($"stock/Getall/{id}").Result;

			List< StockListViewModel> stockListView = Mapper.Map<List<StockListViewModel>>(getstockList);

			ViewBag.stockList = stockListView;

        }
	}
}
