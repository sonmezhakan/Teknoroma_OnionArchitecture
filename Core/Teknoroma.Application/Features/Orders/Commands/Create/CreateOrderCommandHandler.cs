using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Customers.Queries.GetById;
using Teknoroma.Application.Features.OrderDetails.Command.Create;
using Teknoroma.Application.Pipelines.Transaction;
using Teknoroma.Application.Services.EmailServices;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Create
{
	public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, Unit>,ITransactionalRequest
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;
		private readonly IMediator _mediator;
        private readonly IMailService _mailService;

        public CreateOrderCommandHandler(IMapper mapper,IOrderRepository orderRepository,IMediator mediator,IMailService mailService)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
			_mediator = mediator;
            _mailService = mailService;
        }
        public async Task<Unit> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = _mapper.Map<Order>(request);

			await _orderRepository.AddAsync(order);

			CreateOrderDetailCommandRequest createOrderDetailCommandRequest = new CreateOrderDetailCommandRequest
			{
				ID = order.ID,
				CartItems = request.CartItems
			};

			await _mediator.Send(createOrderDetailCommandRequest);

			//Email Sender
            decimal totalPrice = 0;
            string htmlBody = null;

            string startTableHtml = "<table border='1'>" +
				"<thead>" +
				"<tr>"+
				"<th> </th> <th>Ürün</th> <th>Sipariş Adeti</th> <th>Toplam Tutar</th>" +
				"</tr>" +
				"</thead>"+
				"<tbody>";
			
			foreach (var item in request.CartItems)
			{
				totalPrice += item.Quantity * item.UnitPrice;
                htmlBody += $"<tr>" + 
					$"<td><img src='https://www.localhost:7126/images/product/{item.ImagePath}' width='125px' height='75px' /> </td>" +
					$"<td>{item.ProductName}</td> " +
					$"<td>{item.Quantity}</td> " +
					$"<td>{item.Quantity*item.UnitPrice} ₺ </td></tr></body>";
            }

            string endTableHtml = "<tfooter>" +
                "<tr>" +
                "<td></td><td></td><td></td>" +
				$"<td> {totalPrice} ₺ </td>" +
                "</tfooter>" +
                "</table>";

            var getCustomer = await _mediator.Send(new GetByIdCustomerQueryRequest { ID = order.CustomerId });
            await _mailService.SendMailAsync("Siparişiniz Alınmıştır!", 
				null,
				$@"<h2>Teknroma {order.ID} Numaralı Siparişiniz Hazırlanıyor</h2><br>{startTableHtml}{htmlBody}{endTableHtml}",
				getCustomer.Email
			);

			return Unit.Value;
		}
	}
}
