using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryHandler : IRequestHandler<GetByOrderAndProductIdOrderDetailQueryRequest, List<GetByOrderAndProductIdOrderDetailQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderDetailRepository _orderDetailRepository;

		public GetByOrderAndProductIdOrderDetailQueryHandler(IMapper mapper,IOrderDetailRepository orderDetailRepository)
        {
			_mapper = mapper;
			_orderDetailRepository = orderDetailRepository;
		}
        public async Task<List<GetByOrderAndProductIdOrderDetailQueryResponse>> Handle(GetByOrderAndProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			var orderDetails = await _orderDetailRepository.GetAllAsync(x=>x.ID == request.OrderId && x.ProductId == request.ProductId);

			List< GetByOrderAndProductIdOrderDetailQueryResponse> getByOrderAndProductIdOrderDetailQueryResponse = _mapper.Map<List<GetByOrderAndProductIdOrderDetailQueryResponse>>(orderDetails);

			return getByOrderAndProductIdOrderDetailQueryResponse;
		}
	}
}
