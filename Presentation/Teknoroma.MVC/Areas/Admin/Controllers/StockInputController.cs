using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Application.Features.StockInputs.Command.Create;
using Teknoroma.Application.Features.StockInputs.Command.Update;
using Teknoroma.Application.Features.StockInputs.Models;
using Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.StockInputs.Queries.GetById;
using Teknoroma.Application.Features.StockInputs.Queries.GetList;
using Teknoroma.Application.Features.Stocks.Queries.GetByBranchId;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class StockInputController : BaseController
    {

        [HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Create()
        {
            await CheckJwtBearer();
            await ViewBagList();
            return View();
        }
        [HttpPost]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Create(CreateStockInputViewModel model)
        {
            await CheckJwtBearer();
			await ViewBagList();
			if (!ModelState.IsValid)
            {
				return View(model);
            }

            CreateStockInputCommandRequest createStockInput = Mapper.Map<CreateStockInputCommandRequest>(model);
            createStockInput.BranchID = Guid.Parse(ViewBag.Branch.Value);
            createStockInput.AppUserID = CheckAppUser().Result;

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("stockInput/create", createStockInput);

            if (response.IsSuccessStatusCode) return RedirectToAction("Create", "StockInput");

            await HandleErrorResponse(response);
			return View(model);
        }

        [HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
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
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Update(StockInputViewModel model)
        {
            await CheckJwtBearer();
            await ViewBagList();
			if (!ModelState.IsValid)
            {
                 
                return View(model);
            }
            UpdateStockInputCommandRequest updateStockInput = Mapper.Map<UpdateStockInputCommandRequest>(model);
            updateStockInput.BranchID = Guid.Parse(ViewBag.Branch.Value);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("stockInput/update", updateStockInput);

            if (response.IsSuccessStatusCode) return RedirectToAction("Update", model.ID);

            await HandleErrorResponse(response);
            return View(model);
        }

        [HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"stockInput/delete/{id}");

            return RedirectToAction("StockInputList", "StockInput");
        }

        [HttpGet]
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
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
		[Authorize(Roles = "Şube Müdürü,Depo Temsilcisi")]
		public async Task<IActionResult> StockInputList()
        {
            await CheckJwtBearer();
            await BranchViewBag();
            await BranchIDViewBag();

            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockInputQueryResponse>>($"stockInput/GetByBranchIdList/{ViewBag.Branch.Value}");

            if (response == null) return View();

            List<StockInputListViewModel> stockInputListViewModel = Mapper.Map<List<StockInputListViewModel>>(response);

            return View(stockInputListViewModel);
        }

        [HttpGet]
		[Authorize(Roles = "Şube Müdürü")]
		public async Task<IActionResult> StockTrackingReport()
        {
            await CheckJwtBearer();
            await BranchIDViewBag();

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetByBranchIdStockQueryResponse>>($"stock/getbybranchid/{ViewBag.Branch.Value}");
            if(response == null) return View();

            

            return View();
        }

        private async Task<GetByIdStockInputQueryResponse> GetByStockInputId(Guid id)
        {
           return await ApiService.HttpClient.GetFromJsonAsync<GetByIdStockInputQueryResponse>($"stockInput/getbyid/{id}");
        }
        private async Task StockInputViewBag()
        {
			var stockInputs = await ApiService.HttpClient.GetFromJsonAsync<List<GetByBranchIdStockInputQueryResponse>>($"stockInput/GetByBranchIdList/{Guid.Parse(ViewBag.Branch.Value)}");

            ViewBag.StockInputList = stockInputs;
        }

        private async Task ViewBagList()
        {
            await BranchViewBag();
            await BranchIDViewBag();
            await StockInputViewBag();
            await ProductViewBag();
            await SupplierViewBag();
        }
        private async Task BranchViewBag()
        {
            var branches = ApiService.HttpClient.GetFromJsonAsync<List<GetAllBranchQueryResponse>>("branch/getall").Result
                .Select(branch => new GetAllBranchQueryResponse
                {
                    BranchName = branch.BranchName,
                    ID = branch.ID
                });

            ViewBag.BranchList = branches;
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
        private async Task ProductViewBag()
        {
            var products = ApiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall").Result
                .Select(produduct => new GetAllProductQueryResponse
                {
                    ProductName = produduct.ProductName,
                    ID = produduct.ID
                });

            ViewBag.ProductList = products;
        }
        private async Task SupplierViewBag()
        {
            var suppliers = ApiService.HttpClient.GetFromJsonAsync<List<GetAllSupplierQueryResponse>>("supplier/getall").Result
                .Select(supplier => new GetAllSupplierQueryResponse
                {
                    CompanyName = supplier.CompanyName,
                    ID = supplier.ID
                });

            ViewBag.SupplierList = suppliers;
        }    
    }
}
