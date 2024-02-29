using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Customers.Command.Create;
using Teknoroma.Application.Features.Customers.Command.Delete;
using Teknoroma.Application.Features.Customers.Command.Update;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerEarningReport;
using Teknoroma.Application.Features.Customers.Queries.GetCustomerSellingReport;
using Teknoroma.Application.Features.Customers.Queries.GetList;


namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
			var result = await Mediator.Send(createCustomerCommandRequest);

			return Ok(result);
		}

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
			var result = await Mediator.Send(updateCustomerCommandRequest);

			return Ok(result);
		}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
			var result = await Mediator.Send(new DeleteCustomerCommandRequest {ID = id });

			return Ok(result);
		}
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
			var result = await Mediator.Send(new GetByIdCustomerQueryRequest { ID = id });

			return Ok(result);
		}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllCustomerQueryRequest());

			return Ok(result);
		}
        [HttpGet("{startDate}/{endDate}")]
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
