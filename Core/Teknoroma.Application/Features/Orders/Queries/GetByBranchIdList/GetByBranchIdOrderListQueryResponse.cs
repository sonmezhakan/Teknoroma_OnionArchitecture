using Teknoroma.Application.Features.OrderDetails.Models;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Orders.Queries.GetByBranchIdList
{
    public class GetByBranchIdOrderListQueryResponse
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int TotalProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatu OrderStatu { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModels { get; set; }
    }
}
