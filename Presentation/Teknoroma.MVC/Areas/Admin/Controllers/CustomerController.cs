using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Models;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport;
using Teknoroma.Application.Features.Customers.Queries.GetList;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await ErrorResponse();
                return View(model);
            }
            CreateCustomerCommandRequest createCustomer = Mapper.Map<CreateCustomerCommandRequest>(model);

            HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("customer/create", createCustomer);

            if (response.IsSuccessStatusCode) return RedirectToAction("Create", "Customer");

            await HandleErrorResponse(response);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            await CustomerViewBag();

            if (id == null) return View();

            var response = await GetByCustomerId((Guid)id);

            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await CustomerViewBag();
                await ErrorResponse();
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
        public async Task<IActionResult> Delete(Guid id)
        {
             await ApiService.HttpClient.DeleteAsync($"customer/delete/{id}");

            return RedirectToAction("CustomerList", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid? id)
        {
            await CustomerViewBag();

            if(id == null) return View();

            var response = await GetByCustomerId((Guid)id);

            if (response == null) return View();

            CustomerViewModel  customerViewModel = Mapper.Map<CustomerViewModel>(response);

            return View(customerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerQueryResponse>>("customer/getall");

            if(response == null) return View();

            List<CustomerViewModel> customerViewModels = Mapper.Map<List<CustomerViewModel>>(response);

            return View(customerViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> CustomerReport(DateTime? startDate,DateTime? endDate)
        {
            if(startDate == null || endDate == null)
            {
                startDate = DateTime.MinValue;
                endDate = DateTime.MaxValue;
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
            var response = ApiService.HttpClient.GetFromJsonAsync<List<GetAllCustomerQueryResponse>>("customer/getall").Result.Select(x => new GetAllCustomerQueryResponse { ID = x.ID, FullName = x.FullName });

                ViewBag.CustomerList = response;
        }
    }
}
