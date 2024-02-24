using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Orders.Queries.GetList
{
	public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;

		public GetAllOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}

		public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
		{
			var getOrders = await _orderRepository.GetAllAsync();

			List<GetAllOrderQueryResponse> getAllOrderQueryResponses = _mapper.Map<List<GetAllOrderQueryResponse>>(getOrders);

			return getAllOrderQueryResponses.OrderBy(x => x.OrderStatu).ToList();
		}
	}
}
