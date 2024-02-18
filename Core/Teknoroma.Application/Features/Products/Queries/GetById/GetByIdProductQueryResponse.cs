using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Products.Queries.GetById
{
	public class GetByIdProductQueryResponse
	{
		public Guid ID { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int CriticalStock { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public Guid BrandId { get; set; }
		public Guid CategoryId { get; set; }
	}
}
