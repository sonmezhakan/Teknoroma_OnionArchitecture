using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Services.OrderDetails;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Command.Update
{
	public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IOrderDetailService _orderDetailService;

		public UpdateOrderDetailCommandHandler(IMediator  mediator,IMapper mapper, IOrderDetailService orderDetailService)
        {
			_mediator = mediator;
			_mapper = mapper;
			_orderDetailService = orderDetailService;
		}
        public async Task<Unit> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailService.GetAsync(x => x.ID == request.OrderId && x.ProductId == request.ProductId);

			//stock Process
			var stock = orderDetail.Order.Branch.stocks.FirstOrDefault(x=>x.BranchId == request.BranchId && x.ProductId == request.ProductId);
			stock.UnitsInStock += orderDetail.Quantity;
			stock.UnitsInStock -= request.Quantity;
			UpdateStockCommandRequest updateStockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
			await _mediator.Send(updateStockCommandRequest);


			//OrderDetail Process
			orderDetail = _mapper.Map(request, orderDetail);
			await _orderDetailService.UpdateAsync(orderDetail);

			return Unit.Value;
		}
	}
}
