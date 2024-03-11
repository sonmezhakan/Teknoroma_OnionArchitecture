using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.StockInputs.Command.Create;
using Teknoroma.Application.Features.StockInputs.Command.Delete;
using Teknoroma.Application.Features.StockInputs.Command.Update;
using Teknoroma.Application.Features.StockInputs.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.StockInputs.Queries.GetById;
using Teknoroma.Application.Features.StockInputs.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class StockInputController : BaseController
    {
        [HttpPost]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Depo Temsilicisi,Şube Müdürü")]
		public async Task<IActionResult> Create(CreateStockInputCommandRequest createStockInputCommandRequest)
        {
            var result = await Mediator.Send(createStockInputCommandRequest);

            return Ok(result);
        }
        [HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Depo Temsilicisi,Şube Müdürü")]
		public async Task<IActionResult> Update(UpdateStockInputCommandRequest updateStockInputCommandRequest)
        {
            var result = await Mediator.Send(updateStockInputCommandRequest);

            return Ok(result);
        }
        [HttpDelete("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Depo Temsilicisi,Şube Müdürü")]
		public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteStockInputCommandRequest { ID = id });

            return Ok(result);
        }
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Depo Temsilicisi,Şube Müdürü")]
		public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdStockInputQueryRequest { ID = id });

            return Ok(result);
        }
        [HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Depo Temsilicisi,Şube Müdürü")]
		public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllStockInputQueryRequest());

            return Ok(result);
        }
        [HttpGet("{id}")]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Depo Temsilicisi,Şube Müdürü")]
		public async Task<IActionResult> GetByBranchIdList(Guid id)
        {
            var result = await Mediator.Send(new GetByBranchIdStockInputQueryRequest { BranchId = id });

            return Ok(result);
        }
    }
}
