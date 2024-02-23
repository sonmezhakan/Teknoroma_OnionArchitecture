using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.OrderDetails.Command.Create;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Create
{
	public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;
		private readonly IMediator _mediator;

		public CreateOrderCommandHandler(IMapper mapper,IOrderRepository orderRepository,IMediator mediator)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
			_mediator = mediator;
		}
        public async Task<Unit> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = _mapper.Map<Order>(request);

			await _orderRepository.AddAsync(order);

			CreateOrderDetailCommandRequest createOrderDetailCommandRequest = new CreateOrderDetailCommandRequest
			{
				ID = order.ID,
				CartItems = request.CartItems
			};

			await _mediator.Send(createOrderDetailCommandRequest);

			return Unit.Value;
		}
	}
}
