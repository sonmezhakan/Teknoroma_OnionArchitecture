using Teknoroma.Domain.Abstracts;

namespace Teknoroma.Domain.Entities
{
	public class Expense:BaseEntity
	{
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
