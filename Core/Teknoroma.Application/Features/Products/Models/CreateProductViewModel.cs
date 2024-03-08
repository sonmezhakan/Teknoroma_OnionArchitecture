using System.ComponentModel.DataAnnotations;
using Teknoroma.Application.Features.Products.Constants;

namespace Teknoroma.Application.Features.Products.Models
{
	public class CreateProductViewModel
    {
        public CreateProductViewModel()
        {
            UnitsInStock = 0;
        }
		
		[Display(Name = ProductColumnNames.ProductName)]
        [Required(ErrorMessage = ProductsMessages.ProductNameNotNull)]
        public string ProductName { get; set; }

		[Display(Name = ProductColumnNames.BarcodeCode)]
		public string? BarcodeCode { get; set; }

		[Display(Name = ProductColumnNames.UnitPrice)]
        [Required(ErrorMessage = ProductsMessages.UnitPriceNotNull)]
        public decimal UnitPrice { get; set; }

		[Display(Name = ProductColumnNames.UnitsInStock)]
		public int? UnitsInStock { get; set; }

		[Display(Name = ProductColumnNames.CriticalStock)]
        [Required(ErrorMessage = ProductsMessages.CriticalStockNotNull)]
        public int CriticalStock { get; set; }

		[Display(Name = ProductColumnNames.Description)]
		public string? Description { get; set; }

		[Display(Name = ProductColumnNames.ImagePath)]
		public string? ImagePath { get; set; }

		[Display(Name = ProductColumnNames.BrandId)]
		public Guid? BrandId { get; set; }

		[Display(Name = ProductColumnNames.CategoryId)]
        [Required(ErrorMessage = ProductsMessages.CategoryNotNull)]
        public Guid CategoryId { get; set; }
    }
}
