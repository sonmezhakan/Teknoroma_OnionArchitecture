namespace Teknoroma.Application.Features.Expenses.Queries.GetList
{
	public class GetAllExpenseQueryResponse
	{
		public Guid ID { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public DateTime ExpenseDate { get; set; }
		public string? Description { get; set; }
		public string AppUserName { get; set; }
	}
}
