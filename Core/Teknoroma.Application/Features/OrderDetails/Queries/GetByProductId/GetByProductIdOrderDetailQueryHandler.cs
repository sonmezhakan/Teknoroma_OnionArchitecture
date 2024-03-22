using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByProductId
{
	public class GetByProductIdOrderDetailQueryHandler : IRequestHandler<GetByProductIdOrderDetailQueryRequest, List<GetByProductIdOrderDetailQueryResponse>>
	{
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IMapper _mapper;

		public GetByProductIdOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
			_orderDetailRepository = orderDetailRepository;
			_mapper = mapper;
		}
        public async Task<List<GetByProductIdOrderDetailQueryResponse>> Handle(GetByProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			var orderDetails = await _orderDetailRepository.GetAllAsync(x=>x.ProductId == request.ProductId);

			List< GetByProductIdOrderDetailQueryResponse> getByProductIdOrderDetailQueryResponse = _mapper.Map<List<GetByProductIdOrderDetailQueryResponse>>(orderDetails);

			return getByProductIdOrderDetailQueryResponse;
		}
	}
}
