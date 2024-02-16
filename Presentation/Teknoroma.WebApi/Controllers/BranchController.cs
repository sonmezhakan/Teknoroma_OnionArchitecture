using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Branches.Command.Create;
using Teknoroma.Application.Features.Branches.Command.Delete;
using Teknoroma.Application.Features.Branches.Command.Update;
using Teknoroma.Application.Features.Branches.Queries.GetAll;
using Teknoroma.Application.Features.Branches.Queries.GetById;


namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BranchController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Create(CreateBranchCommandRequest createBranchCommandRequest)
		{
			var result = await Mediator.Send(createBranchCommandRequest);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateBranchCommandRequest updateBranchCommandRequest)
		{
			var result = await Mediator.Send(updateBranchCommandRequest);

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await Mediator.Send(new DeleteBranchCommandRequest { ID = id});

			return Ok(result);
		}

		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await Mediator.Send(new GetByIdBranchQueryRequest { ID = id });

			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await Mediator.Send(new GetAllBranchQueryRequest());

			return Ok(result);
		}
	}
}
