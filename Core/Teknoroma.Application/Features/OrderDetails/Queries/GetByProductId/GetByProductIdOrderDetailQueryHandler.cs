using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.OrderDetails;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByProductId
{
	public class GetByProductIdOrderDetailQueryHandler : IRequestHandler<GetByProductIdOrderDetailQueryRequest, List<GetByProductIdOrderDetailQueryResponse>>
	{
		private readonly IOrderDetailService _orderDetailService;
		private readonly IMapper _mapper;

		public GetByProductIdOrderDetailQueryHandler(IOrderDetailService orderDetailService,IMapper mapper)
        {
			_orderDetailService = orderDetailService;
			_mapper = mapper;
		}
        public async Task<List<GetByProductIdOrderDetailQueryResponse>> Handle(GetByProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			var orderDetails = await _orderDetailService.GetAllAsync(x=>x.ProductId == request.ProductId);

			List< GetByProductIdOrderDetailQueryResponse> getByProductIdOrderDetailQueryResponse = _mapper.Map<List<GetByProductIdOrderDetailQueryResponse>>(orderDetails);

			return getByProductIdOrderDetailQueryResponse;
		}
	}
}
