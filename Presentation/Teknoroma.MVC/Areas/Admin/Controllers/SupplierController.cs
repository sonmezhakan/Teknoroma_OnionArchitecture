using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Suppliers.Command.Create;
using Teknoroma.Application.Features.Suppliers.Command.Update;
using Teknoroma.Application.Features.Suppliers.Models;
using Teknoroma.Application.Features.Suppliers.Queries.GetById;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;
using Teknoroma.Application.Repositories;
using Teknoroma.Infrastructure.WebApiService;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class SupplierController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IApiService _apiService;

		public SupplierController(IMapper mapper,IApiService apiService)
        {
			_mapper = mapper;
			_apiService = apiService;
		}
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateSupplierViewModel model)
		{
			if(ModelState.IsValid)
			{
				CreateSupplierCommandRequest createSupplier = _mapper.Map<CreateSupplierCommandRequest>(model);

				HttpResponseMessage response = await _apiService.HttpClient.PostAsJsonAsync("supplier/create", createSupplier);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					return View(model);
				}

				return View();
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Hatalı İşlem");

				return View(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid? id)
		{
			await SupplierViewBag();
			if (id == null) return View();

			var getSupplier = await _apiService.HttpClient.GetFromJsonAsync<GetByIdSupplierQueryResponse>($"supplier/getbyid/{id}");

			SupplierViewModel supplierViewModel = _mapper.Map<SupplierViewModel>(getSupplier);

			return View(supplierViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Update(SupplierViewModel model)
		{
			if(ModelState.IsValid)
			{
				UpdateSupplierCommandRequest updateSupplier = _mapper.Map<UpdateSupplierCommandRequest>(model);

				HttpResponseMessage response = await _apiService.HttpClient.PutAsJsonAsync("supplier/update", updateSupplier);

				if (!response.IsSuccessStatusCode)
				{
					await ErrorResponseViewModel.Instance.CopyForm(response);

					ModelState.AddModelError(ErrorResponseViewModel.Instance.Title, ErrorResponseViewModel.Instance.Detail);

					await SupplierViewBag();

					return View(model);
				}

				return RedirectToAction("Update", model.ID);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Hatalı İşlem!");

				await SupplierViewBag();

				return View(model.ID);
			}
		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _apiService.HttpClient.DeleteAsync($"supplier/delete/{id}");

			return RedirectToAction("SupplierList", "Supplier");
		}
		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{
			await SupplierViewBag();

			if (id == null) return View();

			var getSupplier = await _apiService.HttpClient.GetFromJsonAsync<GetByIdSupplierQueryResponse>($"supplier/getbyid/{id}");

			SupplierViewModel supplierViewModel = _mapper.Map<SupplierViewModel>(getSupplier);

			return View(supplierViewModel);
		}
		[HttpGet]
		public async Task<IActionResult> SupplierList()
		{
			var response = await _apiService.HttpClient.GetFromJsonAsync<List<GetAllSupplierQueryResponse>>("supplier/getall");

			List< SupplierViewModel> supplierViewModel = _mapper.Map<List<SupplierViewModel>>(response);

			return View(supplierViewModel);
		}

		public async Task SupplierViewBag()
		{
			var getSupplierList = _apiService.HttpClient.GetFromJsonAsync<List<GetAllSupplierQueryResponse>>("supplier/getall").Result.Select(x=> new GetAllSupplierQueryResponse
			{
				ID = x.ID,
				CompanyName = x.CompanyName
			}).ToList();

			ViewBag.SupplierList = getSupplierList;
		}
	}
}
