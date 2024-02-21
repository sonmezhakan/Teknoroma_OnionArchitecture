using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.Branches.Command.Update;
using Teknoroma.Application.Features.Branches.Models;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetById;
using Teknoroma.Application.Features.Stocks.Models;
using Teknoroma.Application.Features.Stocks.Queries.GetList;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class BranchController : BaseController
	{

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateBranchViewModel model)
		{
			if(ModelState.IsValid)
			{
				CreateBranchCommandRequest createBranch = Mapper.Map<CreateBranchCommandRequest>(model);

				HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("branch/create", createBranch);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					return View(model);
				}

				return RedirectToAction("Create", "Branch");		
			}
			else
			{
				ModelState.AddModelError(string.Empty,"Hatalı İşlem!");

				return View();
			}
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid? id)
		{
			await BranchViewBag();

			if (id == null) return View();

			var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdBranchQueryResponse>($"branch/getbyid/{id}");

			if(response == null) return View();

			BranchViewModel branchViewModel = Mapper.Map<BranchViewModel>(response);

			return View(branchViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Update(BranchViewModel model)
		{
			if (ModelState.IsValid)
			{
				UpdateBranchCommandRequest updateBranch = Mapper.Map<UpdateBranchCommandRequest>(model);

				HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("branch/update", updateBranch);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					await BranchViewBag();

					return View(model);
				}

				return RedirectToAction("Update", model.ID);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

				await BranchViewBag();

				return View(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			await ApiService.HttpClient.DeleteAsync($"branch/delete/{id}");

			return RedirectToAction("BranchList", "Branch");
		}

		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{
			await BranchViewBag();

			if (id == null) return View();

			var response = await ApiService.HttpClient.GetFromJsonAsync<GetByIdBranchQueryResponse>($"branch/getbyid/{id}");

			if (response == null) return View();

			await stockViewBag(response.ID);

            BranchViewModel branchViewModel = Mapper.Map<BranchViewModel>(response);

			return View(branchViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> BranchList()
		{
			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllBranchQueryResponse>>("branch/getall");

			if (response == null) return View();

			List<BranchListViewModel> branchViewModels = Mapper.Map<List<BranchListViewModel>>(response);

			return View(branchViewModels);
		}

		private async Task BranchViewBag()
		{
			var getBranchList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllBranchQueryResponse>>("branch/getall").Result.Select(x=> new GetAllBranchQueryResponse
			{
				ID = x.ID,
				BranchName = x.BranchName
			}).ToList();

			ViewBag.BranchList = getBranchList;

		}
		private async Task stockViewBag(Guid id)
		{
			var getstockList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockQueryResponse>>($"stock/Getall/{id}").Result;

			List< StockListViewModel> stockListView = Mapper.Map<List<StockListViewModel>>(getstockList);

			ViewBag.stockList = stockListView;

        }
	}
}
