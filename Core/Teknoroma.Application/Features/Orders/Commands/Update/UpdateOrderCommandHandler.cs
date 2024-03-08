using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.EmailService;
using Teknoroma.Application.Services.Orders;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;
		private readonly IMailService _mailService;

        public UpdateOrderCommandHandler(IMapper mapper, IOrderService orderService,IMailService mailService)
        {
			_mapper = mapper;
			_orderService = orderService;
			_mailService = mailService;
        }
        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderService.GetAsync(x => x.ID == request.ID);

			if(order.OrderStatu != Domain.Enums.OrderStatu.Delivered && request.OrderStatu == Domain.Enums.OrderStatu.Delivered)
			{
                //Email Sender
                decimal totalPrice = 0;
                string htmlBody = null;

                string startTableHtml = "<table border='1'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th> </th> <th>Ürün</th> <th>Sipariş Adeti</th> <th>Toplam Tutar</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody>";

                foreach (var item in order.OrderDetails.ToList())
                {
                    totalPrice += item.Quantity * item.UnitPrice;
                    htmlBody += $"<tr>" +
                        $"<td><img src='https://www.localhost:7126/images/product/{item.Product.ImagePath}' width='125px' height='75px' /> </td>" +
                        $"<td>{item.Product.ProductName}</td> " +
                        $"<td>{item.Quantity}</td> " +
                        $"<td>{item.Quantity * item.UnitPrice} ₺ </td></tr>";
                }

                string endTableHtml = "<tfooter>" +
                    "<tr>" +
                    "<td></td><td></td><td></td>" +
                    $"<td> {totalPrice} </td>" +
                    "</tfooter>" +
                    "</table>";

                await _mailService.SendMail(new Mail
                {
                    ToEmail = order.Customer.Email,
                    Subject = "Siparişiniz Teslim Edilmiştir!",
                    HtmlBody = $@"<h2>Teknroma {order.ID} Numaralı Siparişiniz Teslim Edilmiştir</h2><br>{startTableHtml}{htmlBody}{endTableHtml}"
                });
            }

			order = _mapper.Map(request,order);

			await _orderService.UpdateAsync(order);

			return Unit.Value;    
		}
	}
}
