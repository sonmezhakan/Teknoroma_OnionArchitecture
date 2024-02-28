﻿using Microsoft.AspNetCore.Authorization;
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
		public async Task<IActionResult> StockTrackingReport()
		{
			await BranchIDViewBag();

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetStockTrackingReportListQueryResponse>>($"stock/StockTrackingReport/{ViewBag.Branch.Value}");
			if (response == null) return View();

			List<StockTrackingReportViewModel> StockTrackingReport = Mapper.Map<List<StockTrackingReportViewModel>>(response);

			return View(StockTrackingReport);
		}

		private async Task BranchIDViewBag()
		{
			Guid getAppUserID = await CheckAppUser();

			var getEmployeeBranch = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{getAppUserID}");

			ViewBag.Branch = new SelectListItem
			{
				Text = getEmployeeBranch.BranchName,
				Value = getEmployeeBranch.BranchID.ToString(),
			};
		}
		private async Task<Guid> CheckAppUser()
		{
			Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

			return getAppUserID;
		}
	}
}