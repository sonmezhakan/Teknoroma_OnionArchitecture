using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Command.Delete
{
	public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest, Unit>
	{
		private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository,IStockRepository stockRepository)
        {
			_productRepository = productRepository;
            _stockRepository = stockRepository;
        }

		public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetAsync(x => x.ID == request.ID);

			await _productRepository.DeleteAsync(product);

			//Branchlerde bulunan productlar IsActive yapılıyor.
			var branches = await _stockRepository.GetAllAsync(x=>x.ProductId == request.ID);

            await _stockRepository.DeleteRangeAsync(branches);

            return Unit.Value;
		}
	}
}
