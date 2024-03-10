using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Categories.Dtos;
using Teknoroma.Application.Features.Products.Dtos;
using Teknoroma.Application.Features.Products.Models;
using Teknoroma.MVC.Areas.Admin.Controllers;

namespace Teknoroma.MVC.Controllers
{

	public class HomeController : BaseController
    {
		[HttpGet]
		public async Task<IActionResult> Index(string? categoryName)
		{
			await ViewBagCategoryList();

			var products = await ProductHomePageList();

			if (categoryName != null)
			{
				List< ProductHomePageListViewModel> queryProducts = products.Where(x => x.CategoryName == categoryName).ToList();
				return View(queryProducts);
			}

			return View(products);
		}


		private async Task<List<ProductHomePageListViewModel>> ProductHomePageList()
        {
			var response = await ApiService.HttpClient.GetFromJsonAsync<List<ProductHomePageListDto>>("product/ProductHomePageList");

			List<ProductHomePageListViewModel> productHomePageListViewModels = Mapper.Map<List<ProductHomePageListViewModel>>(response);

            return productHomePageListViewModels;
		}

        private async Task ViewBagCategoryList()
        {
            var categories = await ApiService.HttpClient.GetFromJsonAsync<List<CategoryHomePageListDto>>("category/CategoryHomePageList");

            ViewBag.CategoryList = categories;
        }
    }
}
