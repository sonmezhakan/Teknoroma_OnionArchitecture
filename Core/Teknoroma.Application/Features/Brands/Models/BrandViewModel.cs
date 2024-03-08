using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Brands.Contants;

namespace Teknoroma.Application.Features.Brands.Models
{
    public class BrandViewModel
    {
        [Display(Name = BrandColumnNames.ID)]
        [Required(ErrorMessage = BrandsMessages.IDNotNull)]
        public Guid ID { get; set; }

		[Display(Name = BrandColumnNames.BrandName)]
        [Required(ErrorMessage = BrandsMessages.BrandNameNotNull)]
        public string BrandName { get; set; }

		[Display(Name = BrandColumnNames.Description)]
		public string? Description { get; set; }

		[Display(Name = BrandColumnNames.PhoneNumber)]
		public string? PhoneNumber { get; set; }
    }
}
