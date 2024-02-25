using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
		}
        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderRepository.GetAsync(x => x.ID == request.ID);

			order = _mapper.Map(request,order);

			await _orderRepository.UpdateAsync(order);

			return Unit.Value;    
		}
	}
}
