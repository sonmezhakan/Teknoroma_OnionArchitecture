using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Orders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Queries.GetById
{
	public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;

		public GetByIdOrderQueryHandler(IMapper mapper, IOrderService orderService)
        {
			_mapper = mapper;
			_orderService = orderService;
		}
        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderService.GetAsync(x => x.ID == request.ID);

			GetByIdOrderQueryResponse getByIdOrderQueryResponse = _mapper.Map<GetByIdOrderQueryResponse>(order);

			return getByIdOrderQueryResponse;
		}
	}
}
