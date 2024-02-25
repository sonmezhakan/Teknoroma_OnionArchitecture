using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Customers.Contants;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Customers.Models
{
	public class CreateCustomerViewModel
    {
		[Display(Name = CustomerColumnNames.FullName)]
		public string FullName { get; set; }

		[Display(Name = CustomerColumnNames.ContactName)]
		public string? ContactName { get; set; }

		[Display(Name = CustomerColumnNames.ContactTitle)]
		public string? ContactTitle { get; set; }

		[Display(Name = CustomerColumnNames.Email)]
		public string Email { get; set; }

		[Display(Name = CustomerColumnNames.PhoneNumber)]
		public string PhoneNumber { get; set; }

		[Display(Name = CustomerColumnNames.Address)]
		public string? Address { get; set; }

		[Display(Name = CustomerColumnNames.Invoice)]
		public InvoiceEnum Invoice { get; set; }
	}
}
