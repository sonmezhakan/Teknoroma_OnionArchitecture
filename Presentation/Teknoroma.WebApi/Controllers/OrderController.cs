using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId;
using Teknoroma.Application.Features.Orders.Command.Create;
using Teknoroma.Application.Features.Orders.Command.Delete;
using Teknoroma.Application.Features.Orders.Command.Update;
using Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.Orders.Queries.GetById;
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
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderCommandRequest updateOrderCommandRequest)
        {
            var result = await Mediator.Send(updateOrderCommandRequest);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteOrderCommandRequest { ID = id });

            return Ok(result);
        }
        [HttpGet("{branchId}")]
        public async Task<IActionResult> GetByBranchIdOrderList(Guid branchId)
        {
			var result = await Mediator.Send(new GetByBranchIdOrderListQueryRequest { BranchId = (Guid)branchId });
			return Ok(result);
		}
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(Guid orderId)
        {
            var result = await Mediator.Send(new GetByIdOrderQueryRequest { ID = orderId });

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
