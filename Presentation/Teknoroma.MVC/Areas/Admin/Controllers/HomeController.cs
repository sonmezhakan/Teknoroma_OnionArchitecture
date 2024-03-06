using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Brands.Quries.GetBrandSellingReport;
using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Categories.Queries.GetCategorySellingReport;
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
    [Authorize]
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
			await CheckJwtBearer();
            await BranchViewBag();


			DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.MaxValue;

			var categorySellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetCategorySellingReportQueryResponse>>($"category/CategorySellingReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

			List<CategorySellingReportViewModel> categorySellingReportViewModels = Mapper.Map<List<CategorySellingReportViewModel>>(categorySellingReports);

			var productSellingReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSellingReportQueryResponse>>($"product/ProductSellingReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

			var productEarningReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductEarningReportQueryResponse>>($"product/ProductEarningReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

			var brandSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBrandSellingReportQueryResponse>>($"brand/BrandSellingReport/{startDate.ToString("yyyy.MM.dd")}/{endDate.ToString("yyyy.MM.dd")}");

			var orderlist = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllOrderQueryResponse>>($"order/getall");

			List<OrderListViewModel> orderListViewModels = Mapper.Map<List<OrderListViewModel>>(orderlist);

			var stockList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockQueryResponse>>($"stock/getall/{ViewBag.Branch.Value}");


			List<StockListViewModel> stockListViewModel = Mapper.Map<List<StockListViewModel>>(stockList);

			DashboardViewModel dashboardViewModel = new DashboardViewModel
            {
                CategorySellingReportViewModels = categorySellingReportViewModels.Take(10).ToList(),
                DailyBestSalesProduct = productSellingReport.First().ProductName,
                DailyTotalSales = productSellingReport.Sum(x => x.TotalSales),
                DailyTotalPrice = productEarningReport.Sum(x=>x.TotalPrice),
                DailyBestSalesBrand = brandSellingReports.First().BrandName,
                OrderListViewModels = orderListViewModels.Take(10).ToList(),
                StockListViewModels = stockListViewModel
			};
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