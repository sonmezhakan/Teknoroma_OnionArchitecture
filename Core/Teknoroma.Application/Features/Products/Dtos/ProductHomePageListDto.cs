namespace Teknoroma.Application.Features.Products.Dtos
{
	public class ProductHomePageListDto
	{
		public Guid ID { get; set; }
		public string ProductName { get; set; }
		public string CategoryName { get; set; }
		public string BrandName { get; set; }
		public decimal UnitPrice { get; set; }
		public string ImagePath { get; set; }
	}
}
