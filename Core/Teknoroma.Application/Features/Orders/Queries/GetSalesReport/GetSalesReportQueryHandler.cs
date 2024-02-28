using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Orders.Queries.GetSalesReport
{
    public class GetSalesReportQueryHandler : IRequestHandler<GetSalesReportQueryRequest, GetSalesReportQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetSalesReportQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<GetSalesReportQueryResponse> Handle(GetSalesReportQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            //Selling
            var bestSellingProduct = orders.SelectMany(order => order.OrderDetails.Where(x => x.IsActive == true))
                .GroupBy(orderDetail => orderDetail.Product.ProductName)
                .Select(grouped => new
                {
                    ProductName = grouped.Key,
                    TotalSales = grouped.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.TotalSales).FirstOrDefault();

            var bestSellingCategory = orders.SelectMany(order => order.OrderDetails.Where(x => x.IsActive == true))
                .GroupBy(orderDetail => orderDetail.Product.Category.CategoryName)
                .Select(grouped => new
                {
                    CategoryName = grouped.Key,
                    TotalSales = grouped.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.TotalSales).FirstOrDefault();

            var bestSellingBrand = orders.SelectMany(order => order.OrderDetails.Where(x => x.IsActive == true))
                .GroupBy(orderDetail => orderDetail.Product.Brand.BrandName)
                .Select(grouped => new
                {
                    BrandName = grouped.Key,
                    TotalSales = grouped.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.TotalSales).FirstOrDefault();

            var bestSellingCustomer = orders
                .GroupBy(x => x.Customer.FullName)
                .Select(grouped => new
                {
                    FullName = grouped.Key,
                    TotalSales = grouped.Select(order => order.OrderDetails.Where(x => x.IsActive == true)).SelectMany(details => details).Sum(detail => detail.Quantity)
                }).OrderByDescending(x => x.TotalSales).FirstOrDefault();

            var bestSellingBranch = orders
                .GroupBy(x => x.Branch.BranchName)
                .Select(grouped => new
                {
                    BranchName = grouped.Key,
                    TotalSales = grouped.Select(order => order.OrderDetails.Where(x => x.IsActive == true)).SelectMany(details => details)
                    .Sum(detail => detail.Quantity)
                })
                .OrderByDescending(x => x.TotalSales).FirstOrDefault();

            var bestSellingEmployee = orders
                .GroupBy(x => x.Employee.AppUser.UserName)
                .Select(grouped => new
                {
                    UserName = grouped.Key,
                    TotalSales = grouped.Select(order => order.OrderDetails.Where(x => x.IsActive == true)).SelectMany(details => details)
                    .Sum(detail => detail.Quantity)
                }).OrderByDescending(x => x.TotalSales).FirstOrDefault();

            //Earning
            var bestEarningProduct = orders.SelectMany(order => order.OrderDetails.Where(x => x.IsActive == true))
                .GroupBy(orderDetail => orderDetail.Product.ProductName)
                .Select(grouped => new
                {
                    ProductName = grouped.Key,
                    TotalPrice = grouped.Sum(x => x.Quantity * x.UnitPrice)
                }).OrderByDescending(x => x.TotalPrice).FirstOrDefault();

            var bestEarningCategory = orders.SelectMany(order => order.OrderDetails.Where(x => x.IsActive == true))
                .GroupBy(orderDetail => orderDetail.Product.Category.CategoryName)
                .Select(grouped => new
                {
                    CategoryName = grouped.Key,
                    TotalPrice = grouped.Sum(x => x.Quantity * x.UnitPrice)
                }).OrderByDescending(x => x.TotalPrice).FirstOrDefault();

            var bestEarningBrand = orders.SelectMany(order => order.OrderDetails.Where(x => x.IsActive == true))
                .GroupBy(orderDetail => orderDetail.Product.Brand.BrandName)
                .Select(grouped => new
                {
                    BrandName = grouped.Key,
                    TotalPrice = grouped.Sum(x => x.Quantity * x.UnitPrice)
                }).OrderByDescending(x => x.TotalPrice).FirstOrDefault();

            var bestEarningBranch = orders.GroupBy(x => x.Branch.BranchName)
                .Select(grouped => new
                {
                    BranchName = grouped.Key,
                    TotalPrice = grouped.Select(order => order.OrderDetails.Where(x => x.IsActive == true)).SelectMany(details => details)
                    .Sum(detail => detail.Quantity * detail.UnitPrice)
                }).OrderByDescending(x => x.TotalPrice).FirstOrDefault();

            var bestEarningEmployee = orders.GroupBy(x => x.Employee.AppUser.UserName)
                .Select(grouped => new
                {
                    UserName = grouped.Key,
                    TotalPrice = grouped.Select(order => order.OrderDetails.Where(x => x.IsActive == true)).SelectMany(details => details)
                    .Sum(detail => detail.Quantity * detail.UnitPrice)
                }).OrderByDescending(x => x.TotalPrice).FirstOrDefault();

            var bestEarningCustomer = orders.GroupBy(x => x.Customer.FullName)
                .Select(grouped => new
                {
                    FullName = grouped.Key,
                    TotalEarning = grouped.Select(order => order.OrderDetails.Where(x => x.IsActive == true)).SelectMany(details => details)
                    .Sum(detail => detail.Quantity * detail.UnitPrice)
                }).OrderByDescending(x => x.TotalEarning).FirstOrDefault();

            GetSalesReportQueryResponse getSalesReportQueryResponse = new GetSalesReportQueryResponse
            {
                //Selling
                BestSellingProductName = bestSellingProduct.ProductName,
                BestSellingProductQuantity = bestSellingProduct.TotalSales,

                BestSellingCategoryName = bestSellingCategory.CategoryName,
                BestSellingCategoryQuantity = bestSellingCategory.TotalSales,

                BestSellingBranchName = bestSellingBranch.BranchName,
                BestSellingBranchQuantity = bestSellingBranch.TotalSales,

                BestSellingEmployeeName = bestSellingEmployee.UserName,
                BestSellingEmployeeQuantity = bestSellingEmployee.TotalSales,

                BestSellingCustomerName = bestSellingCustomer.FullName,
                BestSellingCustomerQuantity = bestSellingCustomer.TotalSales,

                BestSellingBrandName = bestSellingBrand.BrandName,
                BestSellingBrandQuantity = bestSellingBrand.TotalSales,

                //Earning
                BestEarningProductName = bestEarningProduct.ProductName.ToString(),
                BestEarningProductPrice = bestEarningProduct.TotalPrice,

                BestEarningCategoryName = bestEarningCategory.CategoryName.ToString(),
                BestEarningCategoryPrice = bestEarningCategory.TotalPrice,

                BestEarningBranchName = bestEarningBranch.BranchName.ToString(),
                BestEarningBranchPrice = bestEarningCategory.TotalPrice,

                BestEarningEmployeeName = bestEarningEmployee.UserName.ToString(),
                BestEarningEmployeePrice = bestEarningCategory.TotalPrice,

                BestEarningCustomerName = bestEarningCustomer.FullName.ToString(),
                BestEarningCustomerPrice = bestEarningCategory.TotalPrice,

                BestEarningBrandName = bestEarningBrand.BrandName.ToString(),
                BestEarningBrandPrice = bestEarningBrand.TotalPrice

            };

            return getSalesReportQueryResponse;
        }
    }
}
