using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Features.Customers.Contants;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Customers.Models
{
    public class CreateCustomerViewModel
    {
		[Display(Name = CustomerColumnNames.ID)]
		public Guid ID { get; set; }

		[Display(Name = CustomerColumnNames.FullName)]
		public string FullName { get; set; }

		[Display(Name = CustomerColumnNames.ContactName)]
		public string? ContactName { get; set; }

		[Display(Name = CustomerColumnNames.ContactTitle)]
		public string? ContactTitle { get; set; }

		[Display(Name = CustomerColumnNames.PhoneNumber)]
		public string PhoneNumber { get; set; }

		[Display(Name = CustomerColumnNames.Address)]
		public string? Address { get; set; }

		[Display(Name = CustomerColumnNames.Invoice)]
		public InvoiceEnum Invoice { get; set; }
	}
}
