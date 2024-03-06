using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Suppliers.Command.Create;
using Teknoroma.Application.Features.Suppliers.Command.Delete;
using Teknoroma.Application.Features.Suppliers.Command.Update;
using Teknoroma.Application.Features.Suppliers.Queries.GetById;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;
using Teknoroma.Application.Features.Suppliers.Queries.GetSupplierSupplyDetailReport;
using Teknoroma.Application.Features.Suppliers.Queries.GetSupplyReport;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SupplierController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Create(CreateSupplierCommandRequest createSupplierCommandRequest)
		{
			var result = await Mediator.Send(createSupplierCommandRequest);

			return Ok(result);
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateSupplierCommandRequest updateSupplierCommandRequest)
		{
			var result = await Mediator.Send(updateSupplierCommandRequest);

			return Ok(result);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteSupplierCommandRequest { ID = id });

			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdSupplierQueryRequest { ID = id });

			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllSupplierQueryRequest());

			return Ok(result);
		}
		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> SupplierSupplyReport(string startDate,string endDate)
		{
			var result = await Mediator.Send(new GetSupplierSupplyReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> SupplierSupplyDetailReport(string startDate, string endDate)
		{
			var result = await Mediator.Send(new GetSupplierSupplyDetailReportQueryRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}
	}
}
