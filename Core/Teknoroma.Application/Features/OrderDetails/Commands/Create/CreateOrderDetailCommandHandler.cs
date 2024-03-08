using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Features.Stocks.Queries.GetById;
using Teknoroma.Application.Services.OrderDetails;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Command.Create
{
	public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IOrderDetailService _orderDetailService;
		private readonly IMediator _mediator;

		public CreateOrderDetailCommandHandler(IMapper mapper, IOrderDetailService orderDetailService,IMediator mediator)
        {
			_mapper = mapper;
			_orderDetailService = orderDetailService;
			_mediator = mediator;
		}
        public async Task<Unit> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
		{
			List<OrderDetail> orderDetails = new List<OrderDetail>();
						
			foreach (var item in request.CartItems)
			{
				orderDetails.Add(new OrderDetail
				{
					ID = request.ID,
					ProductId = item.ID,
					Quantity = item.Quantity,
					UnitPrice = item.UnitPrice,
				});

				//Stock Process
				var getStock = await _mediator.Send(new GetByIdStockQueryRequest { BranchID = item.BranchID, ProductID = item.ID });
				getStock.UnitsInStock -= item.Quantity;
				UpdateStockCommandRequest updateStockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(getStock);
				await _mediator.Send(updateStockCommandRequest);		
			}

			await _orderDetailService.AddRangeAsync(orderDetails.ToList());

			return Unit.Value;
		}
	}
}
