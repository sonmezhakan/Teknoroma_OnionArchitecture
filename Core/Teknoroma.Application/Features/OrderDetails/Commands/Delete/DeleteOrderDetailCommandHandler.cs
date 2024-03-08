using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Orders.Command.Delete;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Services.OrderDetails;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Command.Delete
{
	public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IOrderDetailService _orderDetailService;

		public DeleteOrderDetailCommandHandler(IMediator mediator,IMapper mapper,IOrderDetailService orderDetailService)
        {
			_mediator = mediator;
			_mapper = mapper;
			_orderDetailService = orderDetailService;
		}
        public async Task<Unit> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailService.GetAsync(x => x.ID == request.OrderId && x.ProductId == request.ProductId);

			//stock process
			var stock = orderDetail.Order.Branch.stocks.FirstOrDefault(x => x.BranchId == request.BranchId && x.ProductId == request.ProductId);
			stock.UnitsInStock += orderDetail.Quantity;
			UpdateStockCommandRequest updateStockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
			await _mediator.Send(updateStockCommandRequest);


			//OrderDetail process
			await _orderDetailService.DeleteAsync(orderDetail);

			if(_orderDetailService.GetAllAsync(x=>x.ID == request.OrderId).Result.Count() <=0)
			{
				await _mediator.Send(new DeleteOrderCommandRequest { ID = request.OrderId });
			}

			return Unit.Value;
		}
	}
}
