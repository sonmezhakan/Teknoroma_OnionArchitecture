using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.OrderDetails.Command.Delete;
using Teknoroma.Application.Features.OrderDetails.Command.Update;
using Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId;

namespace Teknoroma.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderDetailController : BaseController
	{
		[HttpPut]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Sipariş Güncelle")]
		public async Task<IActionResult> Update(UpdateOrderDetailCommandRequest updateOrderDetailCommandRequest)
		{
			var result = await Mediator.Send(updateOrderDetailCommandRequest);

			return Ok(result);
		}
		[HttpDelete]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Sipariş Sil")]
		public async Task<IActionResult> Delete(Guid orderId, Guid productId, Guid branchId)
		{
			var result = await Mediator.Send(new DeleteOrderDetailCommandRequest {OrderId = orderId, ProductId = productId , BranchId = branchId });

			return Ok(result);
		}

		[HttpGet]
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Sipariş Sorgula")]
		public async Task<IActionResult> GetByOrderAndProductId(GetByOrderAndProductIdOrderDetailQueryRequest getByOrderAndProductIdOrderDetailQueryRequest)
		{
			var result = await Mediator.Send(new GetByOrderAndProductIdOrderDetailQueryRequest { OrderId = getByOrderAndProductIdOrderDetailQueryRequest.OrderId, ProductId = getByOrderAndProductIdOrderDetailQueryRequest.ProductId });

			return Ok(result);
		}
	}
}
