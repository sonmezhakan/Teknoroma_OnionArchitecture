using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Application.Features.OrderDetails.Command.Delete;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Delete
{
	public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public DeleteOrderCommandHandler(IMediator mediator,IMapper mapper, IOrderRepository orderRepository)
        {
			_mediator = mediator;
			_mapper = mapper;
			_orderRepository = orderRepository;
		}
        public async Task<Unit> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderRepository.GetAsync(x=>x.ID == request.ID);

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

			await _orderRepository.DeleteAsync(order);

			return Unit.Value;
		}
	}
}
