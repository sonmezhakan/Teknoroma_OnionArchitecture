using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Application.Features.StockInputs.Command.Create;
using Teknoroma.Application.Features.StockInputs.Command.Update;
using Teknoroma.Application.Features.StockInputs.Models;
using Teknoroma.Application.Features.StockInputs.Queries.GetById;
using Teknoroma.Application.Features.StockInputs.Queries.GetList;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class StockInputController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IMapper _mapper;

        public StockInputController(IApiService apiService, IMapper mapper)
        {
            _apiService = apiService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await StockInputViewBag();
            await BranchViewBag();
            await ProductViewBag();
            await SupplierViewBag();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStockInputViewModel model)
        {
            if(ModelState.IsValid)
            {
                var responseAppUser = await _apiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}");

                CreateStockInputCommandRequest createStockInput = _mapper.Map<CreateStockInputCommandRequest>(model);
                createStockInput.AppUserID = responseAppUser.ID;

                HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("stockInput/create", createStockInput);

                if (response.IsSuccessStatusCode) return RedirectToAction("Create", "StockInput");

                await ErrorResponseViewModel.Instance.CopyForm(response);

                ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem");

                await StockInputViewBag();
                await BranchViewBag();
                await ProductViewBag();
                await SupplierViewBag();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            await StockInputViewBag();
            await BranchViewBag();
            await ProductViewBag();
            await SupplierViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdStockInputQueryResponse>($"stockInput/getbyid/{id}");

            if(response == null) return View();

            StockInputViewModel stockInputViewModel = _mapper.Map<StockInputViewModel>(response);

            return View(stockInputViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockInputViewModel model)
        {
            if(ModelState.IsValid)
            {
                UpdateStockInputCommandRequest updateStockInput = _mapper.Map<UpdateStockInputCommandRequest>(model);

                HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("stockInput/update", updateStockInput);

                if (response.IsSuccessStatusCode) return RedirectToAction("Update", model.ID);

                await ErrorResponseViewModel.Instance.CopyForm(response);

                ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

                await StockInputViewBag();
                await BranchViewBag();
                await ProductViewBag();
                await SupplierViewBag();

                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hatalı İşlem");

                await StockInputViewBag();
                await BranchViewBag();
                await ProductViewBag();
                await SupplierViewBag();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _apiService.HttpClient.DeleteAsync($"stockInput/delete/{id}");

            return RedirectToAction("StockInputList", "StockInput");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await StockInputViewBag();
            await BranchViewBag();
            await ProductViewBag();
            await SupplierViewBag();

            if (id == null) return View();

            var response = await _apiService.HttpClient.GetFromJsonAsync<GetByIdStockInputQueryResponse>($"stockInput/getbyid/{id}");

            if (response == null) return View();

            StockInputViewModel stockInputViewModel = _mapper.Map<StockInputViewModel>(response);

            return View(stockInputViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> StockInputList()
        {
            var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllStockInputQueryResponse>>("stockInput/getall");

            if (response == null) return View();

            List<StockInputListViewModel> stockInputListViewModel = _mapper.Map<List<StockInputListViewModel>>(response);

            return View(stockInputListViewModel);
        }

        private async Task StockInputViewBag()
        {
            var stockInputs = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllStockInputQueryResponse>>("stockInput/getall");

            ViewBag.StockInputList = stockInputs;
        }

        private async Task BranchViewBag()
        {
            var branches = _apiService.HttpClient.GetFromJsonAsync<List<GetAllBranchQueryResponse>>("branch/getall").Result
                .Select(branch => new GetAllBranchQueryResponse
                {
                    BranchName = branch.BranchName,
                    ID = branch.ID
                });

            ViewBag.BranchList = branches;
        }

        private async Task ProductViewBag()
        {
            var products = _apiService.HttpClient.GetFromJsonAsync<List<GetAllProductQueryResponse>>("product/getall").Result
                .Select(produduct => new GetAllProductQueryResponse
                {
                    ProductName = produduct.ProductName,
                    ID = produduct.ID
                });

            ViewBag.ProductList = products;
        }
        private async Task SupplierViewBag()
        {
            var suppliers = _apiService.HttpClient.GetFromJsonAsync<List<GetAllSupplierQueryResponse>>("supplier/getall").Result
                .Select(supplier => new GetAllSupplierQueryResponse
                {
                    CompanyName = supplier.CompanyName,
                    ID = supplier.ID
                });

            ViewBag.SupplierList = suppliers;
        }    
    }
}
