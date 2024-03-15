using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Expenses.Contants;

namespace Teknoroma.Application.Features.Expenses.Models
{
	public class CreateExpenseViewModel
	{
		[Display(Name = ExpenseColumnNames.Title)]
		[Required(ErrorMessage = ExpenseMessages.TitleNotNull)]
		public string Title { get; set; }

		[Display(Name = ExpenseColumnNames.Price)]
		[Required(ErrorMessage = ExpenseMessages.PriceNotNull)]
		public decimal Price { get; set; }

		[Display(Name = ExpenseColumnNames.ExpenseDate)]
		[Required(ErrorMessage = ExpenseMessages.ExpenseDateNotNull)]
		public DateTime ExpenseDate { get; set; }

		[Display(Name = ExpenseColumnNames.Description)]
		public string? Description { get; set; }

		public Guid? EmployeeId { get; set; }
	}
}
