using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Products.Dtos;
using Teknoroma.Application.Features.Products.Models;
using Teknoroma.MVC.Areas.Admin.Controllers;

namespace Teknoroma.MVC.Controllers
{
	public class ProductController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Index(Guid id)
		{
			var response = await ApiService.HttpClient.GetFromJsonAsync<ProductPageDto>($"product/GetByIdProductPage/{id}");

			if (response == null) return RedirectToAction("Index","Home");

			ProductPageViewModel productPageViewModel = Mapper.Map<ProductPageViewModel>(response);
			await ViewBagRelatedList(response.CategoryName);

            return View(productPageViewModel);
		}

		private async Task ViewBagRelatedList(string categoryName)
		{
			var response = ApiService.HttpClient.GetFromJsonAsync<List<ProductHomePageListDto>>($"product/ProductHomePageList").Result.Where(x => x.CategoryName == categoryName).Take(4);

			ViewBag.RelatedList = response;
		}
	}
}
