using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList
{
    public class GetByBranchIdOrderListQueryHandler : IRequestHandler<GetByBranchIdOrderListQueryRequest, List<GetByBranchIdOrderListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetByBranchIdOrderListQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<List<GetByBranchIdOrderListQueryResponse>> Handle(GetByBranchIdOrderListQueryRequest request, CancellationToken cancellationToken)
        {
            var getOrders = await _orderRepository.GetAllAsync(x => x.BranchId == request.BranchId);

            List<GetByBranchIdOrderListQueryResponse> getByBranchIdOrderQueryResponse = _mapper.Map<List<GetByBranchIdOrderListQueryResponse>>(getOrders);

            return getByBranchIdOrderQueryResponse;
        }
    }
}
