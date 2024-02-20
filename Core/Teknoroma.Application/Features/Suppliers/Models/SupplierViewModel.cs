using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Models
{
	public class SupplierViewModel
	{
		[Display(Name = SupplierColumnNames.ID)]
		public Guid ID { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string CompanyName { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string? ContactName { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string? ContactTitle { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string? Email { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string? PhoneNumber { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string? Address { get; set; }

		[Display(Name = SupplierColumnNames.ID)]
		public string? WebSite { get; set; }
    }
}
