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
	public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
		}

		public async Task<string> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetAsync(x => x.ID == request.ID);

			await _productRepository.DeleteAsync(product);

			return "Kalıcı Olarak Silindi!";
		}
	}
}
