using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.OrderDetails.Command.Delete;
using Teknoroma.Application.Features.OrderDetails.Command.Update;
using Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId;

namespace Teknoroma.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class OrderDetailController : BaseController
	{
		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderDetailCommandRequest updateOrderDetailCommandRequest)
		{
			var result = await Mediator.Send(updateOrderDetailCommandRequest);

			return Ok(result);
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(Guid orderId, Guid productId, Guid branchId)
		{
			var result = await Mediator.Send(new DeleteOrderDetailCommandRequest {OrderId = orderId, ProductId = productId , BranchId = branchId });

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetByOrderAndProductId(GetByOrderAndProductIdOrderDetailQueryRequest getByOrderAndProductIdOrderDetailQueryRequest)
		{
			var result = await Mediator.Send(new GetByOrderAndProductIdOrderDetailQueryRequest { OrderId = getByOrderAndProductIdOrderDetailQueryRequest.OrderId, ProductId = getByOrderAndProductIdOrderDetailQueryRequest.ProductId });

			return Ok(result);
		}
	}
}
