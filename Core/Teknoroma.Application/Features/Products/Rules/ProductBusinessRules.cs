using Teknoroma.Application.Services.Repositories;

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
