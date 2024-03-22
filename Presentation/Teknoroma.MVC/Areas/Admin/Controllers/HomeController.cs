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
	[Authorize]
	public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
			await CheckJwtBearer();
            await GetBranch();


			DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.MaxValue;

			DashboardViewModel dashboardViewModel = new DashboardViewModel();


            if (User.IsInRole("Ürün Raporları") || User.IsInRole("Marka Raporları"))
			{
                var productSellingReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductSellingReportQueryResponse>>($"product/ProductSellingReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

                var productEarningReport = await ApiService.HttpClient.GetFromJsonAsync<List<GetProductEarningReportQueryResponse>>($"product/ProductEarningReport/{startDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");

                var brandSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetBrandSellingReportQueryResponse>>($"brand/BrandSellingReport/{startDate.ToString("yyyy.MM.dd")}/{endDate.ToString("yyyy.MM.dd")}");

				if (productSellingReport.Count() > 0)
					dashboardViewModel.DailyBestSalesProduct = productSellingReport.First().ProductName;
				else
					dashboardViewModel.DailyBestSalesProduct = "-";

				if(brandSellingReports.Count() > 0)
					dashboardViewModel.DailyBestSalesBrand = brandSellingReports.First().BrandName;
				else
					dashboardViewModel.DailyBestSalesBrand = "-";

				dashboardViewModel.DailyTotalSales = productSellingReport.Sum(x => x.TotalSales);
				dashboardViewModel.DailyTotalPrice = productEarningReport.Sum(x => x.TotalPrice);
				
            }
			
			if(User.IsInRole("Sipariş Listele"))
			{
                var orderlist = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllOrderQueryResponse>>($"order/GetByBranchIdOrderList/{Guid.Parse(ViewData["BranchID"].ToString())}");

               if(orderlist.Count() > 0)
				{
					List<OrderListViewModel> orderListViewModels = Mapper.Map<List<OrderListViewModel>>(orderlist);

					dashboardViewModel.OrderListViewModels = orderListViewModels.Take(10).ToList();
				}
				else
				{
					dashboardViewModel.OrderListViewModels = null;
				}
            }

			if(User.IsInRole("Stok Listele"))
			{
                var stockList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockQueryResponse>>($"stock/getall/{Guid.Parse(ViewData["BranchID"].ToString())}");

                if(stockList.Count() > 0)
				{
					List<StockListViewModel> stockListViewModel = Mapper.Map<List<StockListViewModel>>(stockList);

					dashboardViewModel.StockListViewModels = stockListViewModel;
				}
				else
				{
					dashboardViewModel.StockListViewModels = null;
				}
            }

			return View(dashboardViewModel);
        }

		private async Task<Guid> CheckAppUser()
		{
			Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

			return getAppUserID;
		}
		private async Task GetBranch()
		{
			Guid getAppUserID = await CheckAppUser();

			var getEmployee = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{getAppUserID}");

			ViewData["BranchName"] = getEmployee.BranchName;
			ViewData["BranchID"] = getEmployee.BranchID;

		}
	}
}