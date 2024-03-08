using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.OrderDetails.Command.Delete;
using Teknoroma.Application.Services.Orders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IOrderService _orderService;

		public DeleteOrderCommandHandler(IMediator mediator,IMapper mapper, IOrderService orderService)
        {
			_mediator = mediator;
			_orderService = orderService;
		}
        public async Task<Unit> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderService.GetAsync(x=>x.ID == request.ID);

			//OrderDetail Process
			if(order.OrderDetails.Where(x=>x.IsActive == true).Count() > 0)
			{
				List<OrderDetail> orderDetails = order.OrderDetails;
				foreach (OrderDetail orderDetail in orderDetails)
				{
					await _mediator.Send(new DeleteOrderDetailCommandRequest
					{
						OrderId = orderDetail.ID,
						BranchId = orderDetail.Order.BranchId,
						ProductId = orderDetail.ProductId
					});
				}	
			}

			await _orderService.DeleteAsync(order);

			return Unit.Value;
		}
	}
}
