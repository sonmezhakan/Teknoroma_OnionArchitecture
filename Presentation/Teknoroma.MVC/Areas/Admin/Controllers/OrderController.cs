using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Features.AppUsers.Queries.GetByUserName;
using Teknoroma.Application.Features.Customers.Queries.GetListSelectIdAndPhoneNumber;
using Teknoroma.Application.Features.Employees.Queries.GetById;
using Teknoroma.Application.Features.OrderDetails.Command.Update;
using Teknoroma.Application.Features.Orders.Command.Create;
using Teknoroma.Application.Features.Orders.Command.Update;
using Teknoroma.Application.Features.Orders.Models;
using Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList;
using Teknoroma.Application.Features.Orders.Queries.GetById;
using Teknoroma.Application.Features.Orders.Queries.GetSalesReport;
using Teknoroma.Application.Features.Products.Queries.GetById;
using Teknoroma.Application.Features.Stocks.Models;
using Teknoroma.Application.Features.Stocks.Queries.GetList;
using Teknoroma.Application.Helpers.SessionHelpers;
using Teknoroma.Domain.Enums;

namespace Teknoroma.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class OrderController : BaseController
	{
		[HttpGet]
		[Authorize(Roles = "Sipariş Ekle")]
		public async Task<IActionResult> Index()
		{
            await CheckJwtBearer();
            await GetBranch();
			await CartViewBag();
			await CustomerViewBag();

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllStockQueryResponse>>($"stock/getall/{Guid.Parse(ViewData["BranchID"].ToString())}");

			if(response == null) return View();

			List<StockListViewModel> stockListViewModel = Mapper.Map<List<StockListViewModel>>(response);

			return View(stockListViewModel);
		}
		[HttpPost]
		[Authorize(Roles = "Sipariş Ekle")]
		public async Task<IActionResult> AddToCart(Guid id, int quantity)
		{
            await CheckJwtBearer();
			await CartViewBag();
			await GetBranch();
			Cart cartSession;

			var getProductResponse = await ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{id}");

			if(getProductResponse == null) return View();

			CartItem cartItem = Mapper.Map<CartItem>(getProductResponse);
			cartItem.Quantity = quantity;
			cartItem.BranchID = Guid.Parse(ViewData["BranchID"].ToString());

			if(SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null)
			{
				cartSession = new Cart();
				cartSession.AddItem(cartItem);

				SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
			}
			else
			{
				cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

				if(cartSession._myCart.ContainsKey(id))
				{
					cartItem.Quantity += cartSession._myCart[id].Quantity;
					cartSession.UpdateItem(cartItem);
				}
				else if(!cartSession._myCart.ContainsKey(id))
				{
					cartSession.AddItem(cartItem);
				}
				SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
			}

			return RedirectToAction("Index", "Order");
		}

		[HttpPost]
		[Authorize(Roles = "Sipariş Ekle")]
		public async Task<IActionResult> CartItemDelete(Guid id)
		{
            await CheckJwtBearer();

            Cart cartSession;

			if(SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
			{
				cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

				if(cartSession._myCart.ContainsKey(id))
				{
					cartSession.DeleteItem(cartSession._myCart[id]);
					SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
				}
			}

			return RedirectToAction("Index", "Order");
		}

		[HttpPost]
		[Authorize(Roles = "Sipariş Ekle")]
		public async Task<IActionResult> CompleteCart(Guid customerId)
		{
            await CheckJwtBearer();
			await GetBranch();
			Cart cartSession;

			if(SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
			{
				cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

				List<CartItem> cartItems = new List<CartItem>();
				foreach (var item in cartSession._myCart)
				{
					cartItems.Add(new CartItem
					{
						ID = item.Value.ID,
						BranchID = item.Value.BranchID,
						Quantity = item.Value.Quantity,
						UnitPrice = item.Value.UnitPrice,

						ImagePath = item.Value.ImagePath,
						ProductName = item.Value.ProductName
					});
				}

				CreateOrderCommandRequest createOrderCommandRequest = new CreateOrderCommandRequest
				{
					BranchId = Guid.Parse(ViewData["BranchID"].ToString()),
					EmployeeId = CheckAppUser().Result,
					CustomerId = customerId,
					OrderDate = DateTime.Now,
					OrderStatu = Domain.Enums.OrderStatu.GettingReady,
					CartItems = cartItems
				};

				HttpResponseMessage response = await ApiService.HttpClient.PostAsJsonAsync("order/create", createOrderCommandRequest);
				
				if(response.IsSuccessStatusCode)
				{
					cartSession.AllDelete();
					cartSession = null;
					SessionHelper.SetJsonProduct(HttpContext.Session, "sepet", cartSession);
				}
			}

			return RedirectToAction("Index", "Order");
		}


		[HttpGet]
		[Authorize(Roles = "Sipariş Listele")]
		public async Task<IActionResult> OrderList()
		{
            await CheckJwtBearer();
			await GetBranch();

			var response = await ApiService.HttpClient.GetFromJsonAsync<List<GetByBranchIdOrderListQueryResponse>>($"order/GetByBranchIdOrderList/{Guid.Parse(ViewData["BranchID"].ToString())}");

			if (response == null) return View();

			List<OrderListViewModel> orderListViewModels = Mapper.Map<List<OrderListViewModel>>(response);

			return View(orderListViewModels);
		}

		[HttpPost]
		[Authorize(Roles = "Sipariş Güncelle")]
		public async Task<IActionResult> UpdateOrderDetail(Guid orderId,Guid productId,int quantity)
		{
            await CheckJwtBearer();
			await GetBranch();
			var getProduct = await ApiService.HttpClient.GetFromJsonAsync<GetByIdProductQueryResponse>($"product/getbyid/{productId}");

			UpdateOrderDetailCommandRequest updateOrderDetailCommandRequest = new UpdateOrderDetailCommandRequest
			{
				BranchId = Guid.Parse(ViewData["BranchID"].ToString()),
				OrderId = orderId,
				ProductId = productId,
				Quantity = quantity,
				UnitPrice = getProduct.UnitPrice
			};

			await ApiService.HttpClient.PutAsJsonAsync("orderDetail/Update", updateOrderDetailCommandRequest);

			return RedirectToAction("OrderList", "Order");
		}

		[HttpGet]
		[Authorize(Roles = "Sipariş Sil")]
		public async Task<IActionResult> DeleteOrderDetail(Guid orderId,Guid productId)
		{
            await CheckJwtBearer();
			await GetBranch();
			await ApiService.HttpClient.DeleteAsync($"orderdetail/delete?orderId={orderId}&productId={productId}&branchId={Guid.Parse(ViewData["BranchID"].ToString())}");

			return RedirectToAction("OrderList", "Order");
		}

		[HttpGet]
		[Authorize(Roles = "Sipariş Durum Güncelle")]
		public async Task<IActionResult> UpdateOrderStatu(Guid orderId,OrderStatu orderStatu)
		{
            await CheckJwtBearer();
            var getOrder = await ApiService.HttpClient.GetFromJsonAsync<GetByIdOrderQueryResponse>($"order/getbyid/{orderId}");
			getOrder.OrderStatu = orderStatu;

			UpdateOrderCommandRequest updateOrderCommandRequest = Mapper.Map<UpdateOrderCommandRequest>(getOrder);

			await ApiService.HttpClient.PutAsJsonAsync("order/update", updateOrderCommandRequest);

			return RedirectToAction("OrderList", "Order");
		}

		[HttpGet]
		[Authorize(Roles = "Sipariş Sil")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await CheckJwtBearer();
			await ApiService.HttpClient.DeleteAsync($"order/Delete/{id}");

			return RedirectToAction("OrderList", "Order");
		}


		[HttpGet]
		[Authorize(Roles = "Sipariş Raporları")]
		public async Task<IActionResult> SaleReport()
		{
            await CheckJwtBearer();
            var response = await ApiService.HttpClient.GetFromJsonAsync<GetSalesReportQueryResponse>("order/salesreport");

			if (response == null) return View();

			SalesReportViewModel salesReportViewModel = Mapper.Map<SalesReportViewModel>(response);

			return View(salesReportViewModel);
		}

		private async Task GetBranch()
		{
			Guid getAppUserID = await CheckAppUser();

			var getEmployee = await ApiService.HttpClient.GetFromJsonAsync<GetByIdEmployeeQueryResponse>($"employee/getbyid/{getAppUserID}");

			ViewData["BranchName"] = getEmployee.BranchName;
			ViewData["BranchID"] = getEmployee.BranchID;

		}

		private async Task CartViewBag()
		{
			Cart cartSession;

			if(SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
			{
				cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

				ViewBag.CartList = cartSession._myCart;
			}
		}
		private async Task CustomerViewBag()
		{
			var getCustomerList = await ApiService.HttpClient.GetFromJsonAsync<List<GetAllSelectIdAndPhoneNumberCustomerQueryResponse>>("customer/GetAllSelectIdAndPhoneNumber");
			ViewBag.CustomerList = getCustomerList;
		}

		private async Task<Guid> CheckAppUser()
		{
			Guid getAppUserID = ApiService.HttpClient.GetFromJsonAsync<GetByUserNameAppUserQueryResponse>($"user/GetByUserName/{User.Identity.Name}").Result.ID;

			return getAppUserID;
		}

	}
}
