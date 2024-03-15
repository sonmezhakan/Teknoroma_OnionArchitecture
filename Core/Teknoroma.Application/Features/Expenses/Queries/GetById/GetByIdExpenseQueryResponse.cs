namespace Teknoroma.Application.Features.Expenses.Queries.GetById
{
	public class GetByIdExpenseQueryResponse
	{
		public Guid ID { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public DateTime ExpenseDate { get; set; }
		public string? Description { get; set; }

		public Guid EmployeeId { get; set; }
	}
}
