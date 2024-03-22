using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetList
{
	public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQueryRequest, List<GetAllOrderDetailQueryResponse>>
	{
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IMapper _mapper;

		public GetAllOrderDetailQueryHandler(IMapper mapper,IOrderDetailRepository orderDetailRepository)
        {
			_orderDetailRepository = orderDetailRepository;
			_mapper = mapper;
		}
        public async Task<List<GetAllOrderDetailQueryResponse>> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			var orderDetails = await _orderDetailRepository.GetAllAsync();

			List<GetAllOrderDetailQueryResponse> getAllOrderDetailQueryResponses = _mapper.Map<List<GetAllOrderDetailQueryResponse>>(orderDetails);

			return getAllOrderDetailQueryResponses;
		}
	}
}
