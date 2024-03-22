using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Models;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport;
using Teknoroma.Application.Features.Customers.Queries.GetList;
using Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndName;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize]
    public class CustomerController : BaseController
    {

        [HttpGet]
		[Authorize(Roles = "Müşteri Ekle")]
		public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
		[Authorize(Roles = "Müşteri Ekle")]
		public async Task<IActionResult> Create(CreateCustomerViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
				return View(model);

			CreateCustomerCommandRequest createCustomer = Mapper.Map<CreateCustomerCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("customer/create", createCustomer);

            if (response.IsSuccessStatusCode) return RedirectToAction("Create", "Customer");

            await HandleErrorResponse(response);
            return View(model);
        }

        [HttpGet]
		[Authorize(Roles = "Müşteri Güncelle")]
		public async Task<IActionResult> Update(Guid? id)
        {
            await CheckJwtBearer();
            await CustomerViewBag();

            if (id == null) return View();

            var response = await GetByCustomerId((Guid)id);

            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }
        [HttpPost]
		[Authorize(Roles = "Müşteri Güncelle")]
		public async Task<IActionResult> Update(CustomerViewModel model)
        {
            await CheckJwtBearer();
            if (!ModelState.IsValid)
            {
                await CustomerViewBag();
                return View(model);
            }
            UpdateCustomerCommandRequest updateCustomer = Mapper.Map<UpdateCustomerCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PutAsJsonAsync("customer/update", updateCustomer);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
                await CustomerViewBag();
                return View(model);
            }

            return RedirectToAction("Update", model.ID);
        }

        [HttpGet]
		[Authorize(Roles = "Müşteri Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
            await CheckJwtBearer();
            await ApiService.HttpClient.DeleteAsync($"customer/delete/{id}");

            return RedirectToAction("CustomerList", "Customer");
        }

        [HttpGet]
		[Authorize(Roles = "Müşteri Detayları")]
		public async Task<IActionResult> Detail(Guid? id)
        {
            await CheckJwtBearer();
            await CustomerViewBag();

            if(id == null) return View();

            var response = await GetByCustomerId((Guid)id);

            if (response == null) return View();

            CustomerViewModel  customerViewModel = Mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }

        [HttpGet]
		[Authorize(Roles = "Müşteri Listele")]
		public async Task<IActionResult> CustomerList()
        {
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerQueryResponse>>("customer/getall");

            if(response == null) return View();

            List<CustomerViewModel> customerViewModels = Mapper.Map<List<CustomerViewModel>>(response);

            return View(customerViewModels);
        }
        [HttpGet]
		[Authorize(Roles = "Müşteri Raporları")]
		public async Task<IActionResult> CustomerReport(DateTime? startDate,DateTime? endDate)
        {
            await CheckJwtBearer();
            if (startDate == null || endDate == null)
            {
                startDate = DateTime.MinValue;
                endDate = DateTime.MaxValue;
            }
            else
            {
                endDate = endDate.Value.AddDays(1);
            }
            var customerSellingReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetCustomerSellingReportQueryResponse>>($"customer/CustomerSellingReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List <CustomerSellingReportViewModel> customerSellingReportViewModels = Mapper.Map<List<CustomerSellingReportViewModel>>(customerSellingReports);

            var customerEarningReports = await ApiService.HttpClient.GetFromJsonAsync<List<GetCustomerEarningReportQueryResponse>>($"customer/CustomerEarningReport/{startDate?.ToString("yyyy-MM-dd")}/{endDate?.ToString("yyyy-MM-dd")}");

            List<CustomerEarningReportViewModel> customerEarningReportViewModels = Mapper.Map<List<CustomerEarningReportViewModel>>(customerEarningReports);

            CustomerReportViewModel customerReportViewModel = new CustomerReportViewModel
            {
                CustomerEarningReportViewModels = customerEarningReportViewModels,
                CustomerSellingReportViewModels = customerSellingReportViewModels
            };
            return View(customerReportViewModel);
        }
        private async Task<GetByIdCustomerQueryResponse> GetByCustomerId(Guid id)
        {
          return await ApiService.HttpClient.GetFromJsonAsync<GetByIdCustomerQueryResponse>($"customer/getbyid/{id}");
        }

        private async Task CustomerViewBag()
        {
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndNameCustomerQueryResponse>>("customer/GetAllSelectIdAndName");

                ViewBag.CustomerList = response;
        }
    }
}
