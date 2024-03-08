using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.OrderDetails;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
    public class GetByOrderAndProductIdOrderDetailQueryHandler : IRequestHandler<GetByOrderAndProductIdOrderDetailQueryRequest, GetByOrderAndProductIdOrderDetailQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderDetailService _orderDetailService;

		public GetByOrderAndProductIdOrderDetailQueryHandler(IMapper mapper,IOrderDetailService orderDetailService)
        {
			_mapper = mapper;
			_orderDetailService = orderDetailService;
		}
        public async Task<GetByOrderAndProductIdOrderDetailQueryResponse> Handle(GetByOrderAndProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailService.GetAsync(x=>x.ID == request.OrderId && x.ProductId == request.ProductId);

			GetByOrderAndProductIdOrderDetailQueryResponse getByOrderAndProductIdOrderDetailQueryResponse = _mapper.Map<GetByOrderAndProductIdOrderDetailQueryResponse>(orderDetail);

			return getByOrderAndProductIdOrderDetailQueryResponse;
		}
	}
}
