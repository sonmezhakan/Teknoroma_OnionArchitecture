using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Teknoroma.Application.Services.EmailServices;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Orders.Command.Update
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;
		private readonly IMailService _mailService;
		private readonly UserManager<AppUser> _userManager;

		public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository,IMailService mailService,UserManager<AppUser> userManager)
        {
			_mapper = mapper;
			_orderRepository = orderRepository;
			_mailService = mailService;
			_userManager = userManager;
		}
        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
		{
			Order order = await _orderRepository.GetAsync(x => x.ID == request.ID);

			if(order.OrderStatu != Domain.Enums.OrderStatu.Delivered && request.OrderStatu == Domain.Enums.OrderStatu.Delivered)
			{
				//Email Sender
				await CustomerMailSender(order);

				foreach (var item in order.OrderDetails.ToList())
				{
					if(item.Product.CriticalStock > item.Order.Branch.stocks.FirstOrDefault(x=>x.ProductId == item.ProductId).UnitsInStock)
					{
						await StockAmountDroppedBelowCriticalAmount(item.Order.BranchId,item.Product.ProductName);
					}
				}
            }

			order = _mapper.Map(request,order);

			await _orderRepository.UpdateAsync(order);

			return Unit.Value;    
		}

        private async Task CustomerMailSender(Order order)
        {
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
					$"<td>{item.Quantity * item.UnitPrice} ₺ </td></tr></body>";
			}

			string endTableHtml = "<tfooter>" +
				"<tr>" +
				"<td></td><td></td><td></td>" +
				$"<td> {totalPrice} </td>" +
				"</tfooter>" +
				"</table>";

			await _mailService.SendMailAsync("Siparişiniz Teslim Edilmiştir!",
				null,
				$@"<h2>Teknroma {order.ID} Numaralı Siparişiniz Teslim Edilmiştir</h2><br>{startTableHtml}{htmlBody}{endTableHtml}",
				order.Customer.Email);
		}

		private async Task StockAmountDroppedBelowCriticalAmount(Guid branchId, string productName)
		{
			var employees =  _userManager.Users.Where(x => x.Employee.BranchID == branchId && x.Employee.Department.DepartmentName == "Şube Müdürü").ToList();

			foreach (var item in employees)
			{
				await _mailService.SendMailAsync($"{productName} - Kritik Miktarın Altına Düşmüştür!",
					null,
					$"<h2>{productName} - Kritik Miktarın Altına Düşmüştür!</h2>",
					item.Email);
			}
		}
	}
}
