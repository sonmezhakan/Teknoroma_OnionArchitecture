using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Employees.Command.Create;
using Teknoroma.Application.Features.Employees.Command.Delete;
using Teknoroma.Application.Features.Employees.Command.Update;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.Employees.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class EmployeeController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Create(CreateEmployeeCommandRequest createEmployeeCommandRequest)
		{
			var result = await Mediator.Send(createEmployeeCommandRequest);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateEmployeeCommandRequest updateEmployeeCommandRequest)
		{
			var result = await Mediator.Send(updateEmployeeCommandRequest);

			return Ok(result);
		}
		/*[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteEmployeeCommandRequest { ID = id });

			return Ok(result);
		}*/
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdEmployeeQueryRequest { ID = id });

			return Ok(result);	
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllEmployeeQueryRequest());

			return Ok(result);
		}
	}
}
