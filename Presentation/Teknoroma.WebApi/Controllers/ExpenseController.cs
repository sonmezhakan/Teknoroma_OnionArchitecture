using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Expenses.Commands.Create;
using Teknoroma.Application.Features.Expenses.Commands.Delete;
using Teknoroma.Application.Features.Expenses.Commands.Update;
using Teknoroma.Application.Features.Expenses.Queries.GetById;
using Teknoroma.Application.Features.Expenses.Queries.GetExpenseDetailReport;
using Teknoroma.Application.Features.Expenses.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer", Roles = "Şube Müdürü,Muhasebe Temsilcisi")]
	public class ExpenseController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Create(CreateExpenseCommandRequest createExpenseCommandRequest)
		{
			var result = await Mediator.Send(createExpenseCommandRequest);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateExpenseCommandRequest updateExpenseCommandRequest)
		{
			var result = await Mediator.Send(updateExpenseCommandRequest);

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteExpenseCommandRequest { ID = id });

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdExpenseQueryRequest { ID = id });

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllExpenseQueryRequest());

			return Ok(result);
		}

		[HttpGet("{startDate}/{endDate}")]
		public async Task<IActionResult> ExpenseReport(string startDate, string endDate)
		{
			var result = await Mediator.Send(new GetExpenseDetailReportRequest { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) });

			return Ok(result);
		}

	}
}
