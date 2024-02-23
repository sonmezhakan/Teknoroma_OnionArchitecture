using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.Orders.Command.Create;
using Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.Orders.Queries.GetList;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommandRequest createOrderCommandRequest)
        {
            var result = await Mediator.Send(createOrderCommandRequest);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBranchIdOrderList(Guid branchId)
        {
			var result = await Mediator.Send(new GetByBranchIdOrderListQueryRequest { BranchId = (Guid)branchId });
			return Ok(result);
		}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			var result = await Mediator.Send(new GetAllOrderQueryRequest());
			return Ok(result);
		}
    }
}
