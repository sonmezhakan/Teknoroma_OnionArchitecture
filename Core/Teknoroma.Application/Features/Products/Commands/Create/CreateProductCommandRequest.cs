﻿using MediatR;
using Teknoroma.Application.Pipelines.Transaction;

namespace Teknoroma.Application.Features.Products.Command.Create
{
	public class CreateProductCommandRequest:IRequest<Unit>, ITransactionalRequest
	{
		public string ProductName { get; set; }
		public string? BarcodeCode { get; set; }
		public decimal? UnitPrice { get; set; }
		public int? UnitsInStock { get; set; }
		public int? CriticalStock { get; set; }
		public string? Description { get; set; }
		public string? ImagePath { get; set; }
		public Guid? BrandId { get; set; }
		public Guid CategoryId { get; set; }
    }
}
