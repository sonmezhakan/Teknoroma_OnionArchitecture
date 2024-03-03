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
		[Display(Name = ProductColumnNames.ID)]
		public Guid ID { get; set; }

		[Display(Name = ProductColumnNames.ProductName)]
		public string ProductName { get; set; }

		[Display(Name = ProductColumnNames.BarcodeCode)]
		public string BarcodeCode { get; set; }

		[Display(Name = ProductColumnNames.UnitPrice)]
		public decimal UnitPrice { get; set; }

		[Display(Name = ProductColumnNames.UnitsInStock)]
		public int? UnitsInStock { get; set; }

		[Display(Name = ProductColumnNames.CriticalStock)]
		public int CriticalStock { get; set; }

		[Display(Name = ProductColumnNames.Description)]
		public string? Description { get; set; }

		[Display(Name = ProductColumnNames.ImagePath)]
		public string? ImagePath { get; set; }

		[Display(Name = ProductColumnNames.BrandId)]
		public Guid? BrandId { get; set; }

		[Display(Name = ProductColumnNames.CategoryId)]
		public Guid CategoryId { get; set; }
    }
}
