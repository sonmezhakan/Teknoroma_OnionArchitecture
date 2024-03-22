using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Queries.GetById
{
	public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQueryRequest, GetByIdOrderDetailQueryResponse>
	{
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IMapper _mapper;

		public GetByIdOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository,IMapper mapper)
        {
			_orderDetailRepository = orderDetailRepository;
			_mapper = mapper;
		}
        public async Task<GetByIdOrderDetailQueryResponse> Handle(GetByIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailRepository.GetAsync(x => x.ID == request.ID);

			GetByIdOrderDetailQueryResponse getByIdOrderDetailQueryResponse = _mapper.Map<GetByIdOrderDetailQueryResponse>(orderDetail);

			return getByIdOrderDetailQueryResponse;
		}
	}
}
