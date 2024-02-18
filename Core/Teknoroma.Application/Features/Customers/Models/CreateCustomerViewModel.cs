using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Domain.Enums;

namespace Teknoroma.Application.Features.Customers.Models
{
    public class CreateCustomerViewModel
    {
        [Required]
        [Display(Name = "Full Name*")]
        public string FullName { get; set; }

        [Display(Name = "Contact Name")]
        public string? ContactName { get; set; }

        [Display(Name = "Contact Title")]
        public string? ContactTitle { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Telefon Numarasını Doğru Giriniz!")]
        [Display(Name = "Phone Number*")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Required]
        [Display(Name = "Invoice*")]
        public InvoiceEnum Invoice { get; set; }
    }
}
