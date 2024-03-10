using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.OrderDetails;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryHandler : IRequestHandler<GetByOrderAndProductIdOrderDetailQueryRequest, List<GetByOrderAndProductIdOrderDetailQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderDetailService _orderDetailService;

		public GetByOrderAndProductIdOrderDetailQueryHandler(IMapper mapper,IOrderDetailService orderDetailService)
        {
			_mapper = mapper;
			_orderDetailService = orderDetailService;
		}
        public async Task<List<GetByOrderAndProductIdOrderDetailQueryResponse>> Handle(GetByOrderAndProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			var orderDetails = await _orderDetailService.GetAllAsync(x=>x.ID == request.OrderId && x.ProductId == request.ProductId);

			List< GetByOrderAndProductIdOrderDetailQueryResponse> getByOrderAndProductIdOrderDetailQueryResponse = _mapper.Map<List<GetByOrderAndProductIdOrderDetailQueryResponse>>(orderDetails);

			return getByOrderAndProductIdOrderDetailQueryResponse;
		}
	}
}
