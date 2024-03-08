using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Orders;

namespace Teknoroma.Application.Features.Orders.Queries.GetList
{
	public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;

		public GetAllOrderQueryHandler(IMapper mapper, IOrderService orderService)
		{
			_mapper = mapper;
			_orderService = orderService;
		}

		public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
		{
			var getOrders = await _orderService.GetAllAsync();

			List<GetAllOrderQueryResponse> getAllOrderQueryResponses = _mapper.Map<List<GetAllOrderQueryResponse>>(getOrders.ToList());

			return getAllOrderQueryResponses.OrderBy(x => x.OrderStatu).ToList();
		}
	}
}
