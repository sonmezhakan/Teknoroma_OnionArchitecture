using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Orders.Command.Delete;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Command.Delete
{
	public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IOrderDetailRepository _orderDetailRepository;

		public DeleteOrderDetailCommandHandler(IMediator mediator,IMapper mapper,IOrderDetailRepository orderDetailRepository)
        {
			_mediator = mediator;
			_mapper = mapper;
			_orderDetailRepository = orderDetailRepository;
		}
        public async Task<Unit> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailRepository.GetAsync(x => x.ID == request.OrderId && x.ProductId == request.ProductId);

			//stock process
			var stock = orderDetail.Order.Branch.stocks.FirstOrDefault(x => x.BranchId == request.BranchId && x.ProductId == request.ProductId);
			stock.UnitsInStock += orderDetail.Quantity;
			UpdateStockCommandRequest updateStockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
			await _mediator.Send(updateStockCommandRequest);

			//Product process
			orderDetail.Product.UnitsInStock += orderDetail.Quantity;
			UpdateProductCommandRequest updateProductCommandRequest = _mapper.Map<UpdateProductCommandRequest>(orderDetail.Product);
			await _mediator.Send(updateProductCommandRequest);

			//OrderDetail process
			await _orderDetailRepository.DeleteAsync(orderDetail);

			if(_orderDetailRepository.GetAllAsync(x=>x.ID == request.OrderId).Result.Count() <=0)
			{
				await _mediator.Send(new DeleteOrderCommandRequest { ID = request.OrderId });
			}

			return Unit.Value;
		}
	}
}
