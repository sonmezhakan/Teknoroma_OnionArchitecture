using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Products.Queries.GetList
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public GetAllProductQueryHandler(IMapper mapper,IProductRepository productRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
		}
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
		{
			List<Product> products = await _productRepository.GetAllAsync(); 

			List< GetAllProductQueryResponse> responses = _mapper.Map<List<GetAllProductQueryResponse>>(products);

			return responses;
		}
	}
}
