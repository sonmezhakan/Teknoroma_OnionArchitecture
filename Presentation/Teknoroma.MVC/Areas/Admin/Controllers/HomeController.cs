using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Orders.Models;
using Teknoroma.Application.Features.Orders.Queries.GetList;
using Teknoroma.Application.Features.Products.Queries.GetProductEarningReport;
using Teknoroma.Application.Features.Products.Queries.GetProductSellingReport;
using Teknoroma.Application.Features.Stocks.Models;
using Teknoroma.Application.Features.Stocks.Queries.GetList;
using Teknoroma.MVC.Areas.Admin.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Şube Müdürü,Satış Temsilcisi,Depo Temsilcisi,Teknik Servis,Muhasebe Temsilcisi")]
	public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
			await CheckJwtBearer();
            await BranchViewBag();


			DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.MaxValue;

			DashboardViewModel dashboardViewModel = new DashboardViewModel();


            if (User.IsInRole("Şube Müdürü"))
			{
                var productSellingReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSellingReportQueryResponse>>($"product/ProductSellingReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

                var productEarningReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductEarningReportQueryResponse>>($"product/ProductEarningReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

                var brandSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBrandSellingReportQueryResponse>>($"brand/BrandSellingReport/{startDate.ToString("yyyy.MM.dd")}/{endDate.ToString("yyyy.MM.dd")}");

				dashboardViewModel.DailyBestSalesProduct = productSellingReport.First().ProductName;
				dashboardViewModel.DailyTotalSales = productSellingReport.Sum(x => x.TotalSales);
				dashboardViewModel.DailyTotalPrice = productEarningReport.Sum(x => x.TotalPrice);
				dashboardViewModel.DailyBestSalesBrand = brandSellingReports.First().BrandName;
            }
			
			if(User.IsInRole("Şube Müdürü") || User.IsInRole("Satış Temsilcisi") || User.IsInRole("Depo Temsilcisi"))
			{
                var orderlist = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllOrderQueryResponse>>($"order/getall");

                List<OrderListViewModel> orderListViewModels = Mapper.Map<List<OrderListViewModel>>(orderlist);

				dashboardViewModel.OrderListViewModels = orderListViewModels.Take(10).ToList();
            }

			if(User.IsInRole("Şube Müdürü") || User.IsInRole("Satış Temsilcisi"))
			{
                var stockList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockQueryResponse>>($"stock/getall/{ViewBag.Branch.Value}");

                List<StockListViewModel> stockListViewModel = Mapper.Map<List<StockListViewModel>>(stockList);

				dashboardViewModel.StockListViewModels = stockListViewModel;
            }

			return View(dashboardViewModel);
        }

		private async Task<Guid> CheckAppUser()
		{
			Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

			return getAppUserID;
		}
		private async Task BranchViewBag()
		{
			Guid getAppUserID = await CheckAppUser();

			var getEmployeeBranch = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{getAppUserID}");

			ViewBag.Branch = new SelectListItem
			{
				Text = getEmployeeBranch.BranchName,
				Value = getEmployeeBranch.BranchID.ToString(),
			};
		}


	}
}