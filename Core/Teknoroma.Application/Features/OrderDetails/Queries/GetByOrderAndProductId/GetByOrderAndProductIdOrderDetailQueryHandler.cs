using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetByOrderAndProductId
{
	public class GetByOrderAndProductIdOrderDetailQueryHandler : IRequestHandler<GetByOrderAndProductIdOrderDetailQueryRequest, GetByOrderAndProductIdOrderDetailQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderDetailRepository _orderDetailRepository;

		public GetByOrderAndProductIdOrderDetailQueryHandler(IMapper mapper,IOrderDetailRepository orderDetailRepository)
        {
			_mapper = mapper;
			_orderDetailRepository = orderDetailRepository;
		}
        public async Task<GetByOrderAndProductIdOrderDetailQueryResponse> Handle(GetByOrderAndProductIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailRepository.GetAsync(x=>x.ID == request.OrderId && x.ProductId == request.ProductId);

			GetByOrderAndProductIdOrderDetailQueryResponse getByOrderAndProductIdOrderDetailQueryResponse = _mapper.Map<GetByOrderAndProductIdOrderDetailQueryResponse>(orderDetail);

			return getByOrderAndProductIdOrderDetailQueryResponse;
		}
	}
}
