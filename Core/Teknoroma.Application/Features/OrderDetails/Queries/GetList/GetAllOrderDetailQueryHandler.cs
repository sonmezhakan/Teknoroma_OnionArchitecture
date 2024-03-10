using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.OrderDetails;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetList
{
	public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQueryRequest, List<GetAllOrderDetailQueryResponse>>
	{
		private readonly IOrderDetailService _orderDetailService;
		private readonly IMapper _mapper;

		public GetAllOrderDetailQueryHandler(IMapper mapper,IOrderDetailService orderDetailService)
        {
			_orderDetailService = orderDetailService;
			_mapper = mapper;
		}
        public async Task<List<GetAllOrderDetailQueryResponse>> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			var orderDetails = await _orderDetailService.GetAllAsync();

			List<GetAllOrderDetailQueryResponse> getAllOrderDetailQueryResponses = _mapper.Map<List<GetAllOrderDetailQueryResponse>>(orderDetails);

			return getAllOrderDetailQueryResponses;
		}
	}
}
