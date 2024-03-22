using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Branches.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.StockInputs.Command.Create;
using Teknoroma.Application.Features.StockInputs.Command.Update;
using Teknoroma.Application.Features.StockInputs.Models;
using Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.StockInputs.Queries.GetById;
using Teknoroma.Application.Features.StockInputs.Queries.GetList;
using Teknoroma.Application.Features.Suppliers.Queries.GetListSelectIdAndName;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class StockInputController : BaseController
    {

        [HttpGet]
		[Authorize(Roles = "Stok Girişi")]
		public async Task<IActionResult> Create()
        {
            await CheckJwtBearer();
            await ViewBagList();
            return View();
        }
        [HttpPost]
		[Authorize(Roles = "Stok Girişi")]
		public async Task<IActionResult> Create(CreateStockInputViewModel model)
        {
            await CheckJwtBearer();
			await ViewBagList();
			if (!ModelState.IsValid)
				return View(model);

			CreateStockInputCommandRequest createStockInput = Mapper.Map<CreateStockInputCommandRequest>(model);
            createStockInput.BranchID = Guid.Parse(ViewData["BranchID"].ToString());
            createStockInput.AppUserID = CheckAppUser().Result;

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("stockInput/create", createStockInput);

            if (response.IsSuccessStatusCode) return RedirectToAction("Create", "StockInput");

            await HandleErrorResponse(response);
			return View(model);
        }

        [HttpGet]
		[Authorize(Roles = "Stok Girişi Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await ViewBagList();

            if (id == null) return View();

            var response = await GetByStockInputId((Guid)id);

            if (response == null) return View();

            StockInputViewModel stockInputViewModel = Mapper.Map<StockInputViewModel>(response);

            return View(stockInputViewModel);
        }

        [HttpPost]
		[Authorize(Roles = "Stok Girişi Güncelle")]
		public async Task<IActionResult> Update(StockInputViewModel model)
        {
            await CheckJwtBearer();
            await ViewBagList();
			if (!ModelState.IsValid)
				return View(model);

			UpdateStockInputCommandRequest updateStockInput = Mapper.Map<UpdateStockInputCommandRequest>(model);
            updateStockInput.BranchID = Guid.Parse(ViewData["BranchID"].ToString());

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("stockInput/update", updateStockInput);

            if (response.IsSuccessStatusCode) return RedirectToAction("Update", model.ID);

            await HandleErrorResponse(response);
            return View(model);
        }

        [HttpGet]
		[Authorize(Roles = "Stok Girişi Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"stockInput/delete/{id}");

            return RedirectToAction("StockInputList", "StockInput");
        }

        [HttpGet]
		[Authorize(Roles = "Stok Giriş Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await ViewBagList();

            if (id == null) return View();

            var response = await GetByStockInputId((Guid)id);

            if (response == null) return View();

            StockInputViewModel stockInputViewModel = Mapper.Map<StockInputViewModel>(response);

            return View(stockInputViewModel);
        }

        [HttpGet]
		[Authorize(Roles = "Stok Girişi Listele")]
		public async Task<IActionResult> StockInputList()
        {
            await CheckJwtBearer();
            await BranchViewBag();
            await GetBranch();

            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockInputQueryResponse>>($"stockInput/GetByBranchIdList/{ViewData["BranchID"]}");

            if (response == null) return View();

            List<StockInputListViewModel> stockInputListViewModel = Mapper.Map<List<StockInputListViewModel>>(response);

            return View(stockInputListViewModel);
        }

        private async Task<GetByIdStockInputQueryResponse> GetByStockInputId(Guid id)
        {
           return await ApiService.HttpClient.GetFromJsonAsync<GetByIdStockInputQueryResponse>($"stockInput/getbyid/{id}");
        }
        private async Task StockInputViewBag()
        {
			var stockInputs = await ApiService.HttpClient.GetFromJsonAsync<List<GetByBranchIdStockInputQueryResponse>>($"stockInput/GetByBranchIdList/{Guid.Parse(ViewData["BranchID"].ToString())}");

            ViewBag.StockInputList = stockInputs;
        }

        private async Task ViewBagList()
        {
            await BranchViewBag();
            await GetBranch();
            await StockInputViewBag();
            await ProductViewBag();
            await SupplierViewBag();
        }
        private async Task BranchViewBag()
        {
            var branches =await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameBranchQueryResponse>>("branch/GetAllSelectIdAndName");

            ViewBag.BranchList = branches;
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
        private async Task ProductViewBag()
        {
            var products =await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameProductQueryResponse>>("product/GetAllSelectIdAndName");

            ViewBag.ProductList = products;
        }
        private async Task SupplierViewBag()
        {
            var suppliers = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameSupplierQueryResponse>>("supplier/GetAllSelectIdAndName");

            ViewBag.SupplierList = suppliers;
        }    
    }
}
