using MediatR;
using Teknoroma.Application.Pipelines.Transaction;


namespace Teknoroma.Application.Features.Products.Command.Update
{
	public class UpdateProductCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
        public Guid ID { get; set; }
        public string ProductName { get; set; }
		public string? BarcodeCode { get; set; }
		public decimal? UnitPrice { get; set; }
		public int? UnitsInStock { get; set; }
		public int? CriticalStock { get; set; }
		public string? Description { get; set; }
		public string? ImagePath { get; set; }
		public Guid? BrandId { get; set; }
		public Guid CategoryId { get; set; }
        public bool? Process { get; set; }
    }
}
