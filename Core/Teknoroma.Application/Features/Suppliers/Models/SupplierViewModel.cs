using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Suppliers.Contants;

namespace Teknoroma.Application.Features.Suppliers.Models
{
	public class SupplierViewModel
	{
		[Display(Name = SupplierColumnNames.ID)]
        [Required(ErrorMessage = SuppliersMessages.IDNotNull)]
        public Guid ID { get; set; }

		[Display(Name = SupplierColumnNames.CompanyName)]
        [Required(ErrorMessage = SuppliersMessages.CompanyNameNotNull)]
        public string CompanyName { get; set; }

		[Display(Name = SupplierColumnNames.ContactName)]
		public string? ContactName { get; set; }

		[Display(Name = SupplierColumnNames.ContactTitle)]
		public string? ContactTitle { get; set; }

		[Display(Name = SupplierColumnNames.Email)]
		public string? Email { get; set; }

		[Display(Name = SupplierColumnNames.PhoneNumber)]
		public string? PhoneNumber { get; set; }

		[Display(Name = SupplierColumnNames.Address)]
		public string? Address { get; set; }

		[Display(Name = SupplierColumnNames.WebSite)]
		public string? WebSite { get; set; }
	}
}
