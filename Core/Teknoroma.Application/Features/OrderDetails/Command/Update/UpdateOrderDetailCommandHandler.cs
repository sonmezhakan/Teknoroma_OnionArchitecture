using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Products.Command.Update;
using Teknoroma.Application.Features.Stocks.Command.Update;
using Teknoroma.Application.Features.Stocks.Queries.GetById;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.OrderDetails.Command.Update
{
	public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, Unit>
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IOrderDetailRepository _orderDetailRepository;

		public UpdateOrderDetailCommandHandler(IMediator  mediator,IMapper mapper, IOrderDetailRepository orderDetailRepository)
        {
			_mediator = mediator;
			_mapper = mapper;
			_orderDetailRepository = orderDetailRepository;
		}
        public async Task<Unit> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
		{
			OrderDetail orderDetail = await _orderDetailRepository.GetAsync(x => x.ID == request.OrderId && x.ProductId == request.ProductId);

			//stock Process
			var stock = orderDetail.Order.Branch.stocks.FirstOrDefault(x=>x.BranchId == request.BranchId && x.ProductId == request.ProductId);
			stock.UnitsInStock += orderDetail.Quantity;
			stock.UnitsInStock -= request.Quantity;
			UpdateStockCommandRequest updateStockCommandRequest = _mapper.Map<UpdateStockCommandRequest>(stock);
			await _mediator.Send(updateStockCommandRequest);

			//product procecess
			orderDetail.Product.UnitsInStock += orderDetail.Quantity;
			orderDetail.Product.UnitsInStock -= request.Quantity;
			UpdateProductCommandRequest updateProductCommandRequest = _mapper.Map<UpdateProductCommandRequest>(orderDetail.Product);
			await _mediator.Send(updateProductCommandRequest);

			//OrderDetail Process
			orderDetail = _mapper.Map(request, orderDetail);
			await _orderDetailRepository.UpdateAsync(orderDetail);

			return Unit.Value;
		}
	}
}
