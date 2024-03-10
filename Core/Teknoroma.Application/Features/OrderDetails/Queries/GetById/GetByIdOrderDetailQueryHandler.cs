using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.OrderDetails;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetById
{
	public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQueryRequest, GetByIdOrderDetailQueryResponse>
	{
		private readonly IOrderDetailService _orderDetailService;
		private readonly IMapper _mapper;

		public GetByIdOrderDetailQueryHandler(IOrderDetailService orderDetailService,IMapper mapper)
        {
			_orderDetailService = orderDetailService;
			_mapper = mapper;
		}
        public async Task<GetByIdOrderDetailQueryResponse> Handle(GetByIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailService.GetAsync(x => x.ID == request.ID);

			GetByIdOrderDetailQueryResponse getByIdOrderDetailQueryResponse = _mapper.Map<GetByIdOrderDetailQueryResponse>(orderDetail);

			return getByIdOrderDetailQueryResponse;
		}
	}
}
