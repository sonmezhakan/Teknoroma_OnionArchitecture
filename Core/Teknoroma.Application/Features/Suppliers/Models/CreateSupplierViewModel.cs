using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Suppliers.Models
{
	public class CreateSupplierViewModel
	{
		[Required]
		[Display(Name = "Firma Adı*")]
		public string CompanyName { get; set; }

		[Display(Name = "İletişim Kurulacak Kişi")]
		public string? ContactName { get; set; }

		[Display(Name = "İletşimde Kurulan Kişinin Departmanı")]
		public string? ContactTitle { get; set; }

		[Display(Name = "Email")]
		public string? Email { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Telefon Numarasını Doğru Giriniz!")]
		[Display(Name = "Telefon Numarası")]
		public string? PhoneNumber { get; set; }

		[Display(Name = "Adres")]
		public string? Address { get; set; }

		[Display(Name = "Web Site")]
		public string? WebSite { get; set; }
    }
}
