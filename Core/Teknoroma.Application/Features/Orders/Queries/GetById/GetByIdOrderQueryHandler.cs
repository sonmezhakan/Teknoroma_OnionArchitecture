using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Queries.GetById
{
	public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public GetByIdOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
		}
        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderRepository.GetAsync(x => x.ID == request.ID);

			GetByIdOrderQueryResponse getByIdOrderQueryResponse = _mapper.Map<GetByIdOrderQueryResponse>(order);

			return getByIdOrderQueryResponse;
		}
	}
}
