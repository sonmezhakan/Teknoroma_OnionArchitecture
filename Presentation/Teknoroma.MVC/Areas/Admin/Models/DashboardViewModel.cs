using Teknoroma.Application.Features.Categories.Models;
using Teknoroma.Application.Features.Orders.Models;
using Teknoroma.Application.Features.Products.Models;
using Teknoroma.Application.Features.Stocks.Models;

namespace Teknoroma.MVC.Areas.Admin.Models
{
	public class DashboardViewModel
	{
        public decimal? DailyTotalPrice { get; set; }
        public int? DailyTotalSales { get; set; }
        public string? DailyBestSalesBrand { get; set; }
        public string? DailyBestSalesProduct { get; set; }

        public List<StockListViewModel>? StockListViewModels { get; set; }
        public List<OrderListViewModel>? OrderListViewModels { get; set; }
    }
}
