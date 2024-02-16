using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Brands.Models
{
    public class CreateBrandViewModel
    {
        [Required]
        [Display(Name = "Brand Name*")]
        public string BrandName { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Telefon Numarasını Doğru Giriniz!")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Statu")]
        public bool? IsActive { get; set; }
    }
}
