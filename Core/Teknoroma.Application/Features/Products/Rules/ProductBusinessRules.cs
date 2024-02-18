using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Products.Rules
{
	public class ProductBusinessRules
	{
		private readonly IProductRepository _productRepository;

		public ProductBusinessRules(IProductRepository productRepository)
        {
			_productRepository = productRepository;
		}
    }
}
