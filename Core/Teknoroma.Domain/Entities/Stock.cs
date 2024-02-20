using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public Stock()
        {
            UnitsInStock = 0;
        }
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
        public int UnitsInStock { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
    }
}
