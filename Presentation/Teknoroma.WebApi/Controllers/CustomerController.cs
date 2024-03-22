using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Delete;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport;
using Teknoroma.Application.Features.Customers.Queries.GetList;
using Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndName;
using Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndPhoneNumber;


namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CustomerController : BaseController
    {

        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Ekle")]
		public async Task<IActionResult> Create(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
			var result = await Mediator.Send(createCustomerCommandRequest);

			return Ok(result);
		}

        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Güncelle")]
		public async Task<IActionResult> Update(UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
			var result = await Mediator.Send(updateCustomerCommandRequest);

			return Ok(result);
		}
        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Sil")]
		public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteCustomerCommandRequest {ID = id });

			return Ok(result);
		}
        
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Sorgula")]
		public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdCustomerQueryRequest { ID = id });

			return Ok(result);
		}
        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Listele")]
		public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllCustomerQueryRequest());

			return Ok(result);
		}
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Listele")]
        public async Task<IActionResult> GetAllSelectIdAndName()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndNameCustomerQueryRequest());

            return Ok(result);
        }
		[HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Listele")]
        public async Task<IActionResult> GetAllSelectIdAndPhoneNumber()
        {
            var result = await Mediator.Send(new GetAllSelectIdAndPhoneNumberCustomerQueryRequest());

            return Ok(result);
        }
        [HttpGet("{startDate}/{endDate}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Raporları")]
		public async Task<IActionResult> CustomerSellingReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetCustomerSellingReportQueryRequest
            {
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate)
            });
            return Ok(result);
        }
        [HttpGet("{startDate}/{endDate}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Müşteri Raporları")]
		public async Task<IActionResult> CustomerEarningReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetCustomerEarningReportQueryRequest
            {
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate)
            });
            return Ok(result);
        }

    }
}
