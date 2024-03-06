using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Suppliers.Command.Create;
using Teknoroma.Application.Features.Suppliers.Command.Update;
using Teknoroma.Application.Features.Suppliers.Models;
using Teknoroma.Application.Features.Suppliers.Queries.GetById;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;
using Teknoroma.Application.Features.Suppliers.Queries.GetSupplierSupplyDetailReport;
using Teknoroma.Application.Features.Suppliers.Queries.GetSupplyReport;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize]
	public class SupplierController : BaseController
	{
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
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await ErrorResponse();
                return View(model);
            }
            CreateSupplierCommandRequest createSupplier = Mapper.Map<CreateSupplierCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("supplier/create", createSupplier);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                return View(model);
            }

            return View();
        }

		[HttpGet]
		public async Task<IActionResult> Update(Guid? id)
		{
            await CheckJwtBearer();
            await SupplierViewBag();
			if (id == null) return View();

			var getSupplier = await GetBySupplierId((Guid)id);

            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(getSupplier);

			return View(supplierViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Update(SupplierViewModel model)
		{
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await SupplierViewBag();
                await ErrorResponse();
                return View(model);
            }
            UpdateSupplierCommandRequest updateSupplier = Mapper.Map<UpdateSupplierCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("supplier/update", updateSupplier);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                await SupplierViewBag();
                return View(model);
            }

            return RedirectToAction("Update", model.ID);
        }
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"supplier/delete/{id}");

			return RedirectToAction("SupplierList", "Supplier");
		}
		[HttpGet]
		public async Task<IActionResult> Detail(Guid? id)
		{
			await SupplierViewBag();

			if (id == null) return View();

			var getSupplier = await GetBySupplierId((Guid)id);


            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(getSupplier);

			return View(supplierViewModel);
		}
		[HttpGet]
		public async Task<IActionResult> SupplierList()
		{
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSupplierQueryResponse>>("supplier/getall");

			List< SupplierViewModel> supplierViewModel = Mapper.Map<List<SupplierViewModel>>(response);

			return View(supplierViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> SupplierReport(DateTime? startDate, DateTime? endDate)
		{
            await CheckJwtBearer();
            if (startDate == null || endDate == null)
			{
				startDate = DateTime.MinValue;
				endDate = DateTime.MaxValue;
			}
			var supplierSupplyReports =await ApiService.HttpClient.GetFromJsonAsync<List<GetSupplierSupplyReportQueryResponse>>($"supplier/SupplierSupplyReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List <SupplierSupplyReportViewModel> supplierSupplyReportViewModels = Mapper.Map<List<SupplierSupplyReportViewModel>>(supplierSupplyReports);


			var supplierSupplyDetailReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetSupplierSupplyDetailReportQueryResponse>>($"supplier/SupplierSupplyDetailReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

			List<SupplierSupplyDetailReportViewModel> supplierSupplyDetailReportViewModels = Mapper.Map<List<SupplierSupplyDetailReportViewModel>>(supplierSupplyDetailReports);

			SupplierReportViewModel supplierReportViewModel = new SupplierReportViewModel
			{
				SupplierSupplyDetailReportViewModels = supplierSupplyDetailReportViewModels,
				SupplierSupplyReportViewModels = supplierSupplyReportViewModels
			};
			return View(supplierReportViewModel);
		}


		private async Task<GetByIdSupplierQueryResponse> GetBySupplierId(Guid id)
		{
			return await ApiService.HttpClient.GetFromJsonAsync<GetByIdSupplierQueryResponse>($"supplier/getbyid/{id}");
        }
        private async Task SupplierViewBag()
		{
			var getSupplierList = ApiService.HttpClient.GetFromJsonAsync<List<GetAllSupplierQueryResponse>>("supplier/getall").Result.Select(x=> new GetAllSupplierQueryResponse
			{
				ID = x.ID,
				CompanyName = x.CompanyName
			}).ToList();

			ViewBag.SupplierList = getSupplierList;
		}
	}
}
