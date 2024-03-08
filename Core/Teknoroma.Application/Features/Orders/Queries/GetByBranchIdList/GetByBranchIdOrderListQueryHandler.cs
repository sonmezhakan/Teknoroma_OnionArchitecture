using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Orders;

namespace Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList
{
	public class GetByBranchIdOrderListQueryHandler : IRequestHandler<GetByBranchIdOrderListQueryRequest, List<GetByBranchIdOrderListQueryResponse>>
    {
        private readonly IMapper _mapper;
		private readonly IOrderService _orderService;

		public GetByBranchIdOrderListQueryHandler(IMapper mapper,IOrderService orderService)
        {
            _mapper = mapper;
			_orderService = orderService;
		}
        public async Task<List<GetByBranchIdOrderListQueryResponse>> Handle(GetByBranchIdOrderListQueryRequest request, CancellationToken cancellationToken)
        {
            var getOrders = await _orderService.GetAllAsync(x => x.BranchId == request.BranchId);

            List<GetByBranchIdOrderListQueryResponse> getByBranchIdOrderQueryResponse = _mapper.Map<List<GetByBranchIdOrderListQueryResponse>>(getOrders.OrderBy(x => x.OrderStatu).ToList());

            return getByBranchIdOrderQueryResponse;
        }
    }
}
