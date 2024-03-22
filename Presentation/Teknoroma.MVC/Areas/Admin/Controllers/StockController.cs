using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Stocks.Models;
using Teknoroma.Application.Features.Stocks.Queries.GetStockTrackingReportList;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class StockController : BaseController
	{
		[HttpGet]
		[Authorize(Roles = "Stok Takip Raporları")]
		public async Task<IActionResult> StockTrackingReport(string? listStatus)
		{
            await CheckJwtBearer();
			await GetBranch();

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetStockTrackingReportListQueryResponse>>($"stock/StockTrackingReport/{Guid.Parse(ViewData["BranchID"].ToString())}");
			if (response == null) return View();
			if(listStatus == "CriticalFilter")
			{
				var selectItems = response.Where(x => x.UnitsInStock < x.CriticalStock);
				List<StockTrackingReportViewModel> stockTrackingReport = Mapper.Map<List<StockTrackingReportViewModel>>(selectItems);

				return View(stockTrackingReport);
			}
			else
			{ 
				List<StockTrackingReportViewModel> stockTrackingReport = Mapper.Map<List<StockTrackingReportViewModel>>(response);
				return View(stockTrackingReport);
			}

			
		}

        private async Task GetBranch()
        {
            Guid getAppUserID = await CheckAppUser();

            var getEmployee = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{getAppUserID}");

			ViewData["BranchName"] = getEmployee.BranchName;
			ViewData["BranchID"] = getEmployee.BranchID;

		}
        private async Task<Guid> CheckAppUser()
		{
			Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

			return getAppUserID;
		}
	}
}
