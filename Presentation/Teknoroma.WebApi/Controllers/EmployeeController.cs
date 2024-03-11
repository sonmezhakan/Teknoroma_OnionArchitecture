using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Employees.Command.Create;
using Teknoroma.Application.Features.Employees.Command.Delete;
using Teknoroma.Application.Features.Employees.Command.Update;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeDetailReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeEarningReport;
using Teknoroma.Application.Features.Employees.Queries.GetEmployeeSellingReport;
using Teknoroma.Application.Features.Employees.Queries.GetFullList;
using Teknoroma.Application.Features.Employees.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	
	public class EmployeeController : BaseController
	{
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
        public async Task<IActionResult> Create(CreateEmployeeCommandRequest createEmployeeCommandRequest)
		{
			var result = await Mediator.Send(createEmployeeCommandRequest);

			return Ok(result);
		}

		[HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
        public async Task<IActionResult> Update(UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
		{
			var result = await Mediator.Send(updateEmployeeCommandRequest);

			return Ok(result);
		}
		[HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
        public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteEmployeeCommandRequest { ID = id });

			return Ok(result);
		}
		[HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi,Satış Temsilcisi,Depo Temsilcisi")]
        public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdEmployeeQueryRequest { ID = id });

			return Ok(result);	
		}
		[HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
        public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllEmployeeQueryRequest());

			return Ok(result);
		}
		[HttpGet("{startDate}/{endDate}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
        public async Task<IActionResult> EmployeeSellingReport(string startDate,string endDate)
		{
			var result = await Mediator.Send(new GetEmployeeSellingReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
        [HttpGet("{startDate}/{endDate}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
        public async Task<IActionResult> EmployeeEarningReport(string startDate, string endDate)
        {
            var result = await Mediator.Send(new GetEmployeeEarningReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

            return Ok(result);
        }
		[HttpGet("{startDate}/{endDate}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü")]
        public async Task<IActionResult> EmployeeDetailReport(string startDate,string endDate)
		{
			var result = await Mediator.Send(new GetEmployeeDetailReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetFullAll()
		{
			var result = await Mediator.Send(new GetFullListEmployeeQueryRequest());

			return Ok(result);
		}
    }
}
