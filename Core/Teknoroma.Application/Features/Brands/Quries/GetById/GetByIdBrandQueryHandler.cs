using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Quries.GetById
{
	public class GetByIdBrandQueryHandler:IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetAsync(x=>x.ID ==  request.ID);

			GetByIdBrandQueryResponse response = _mapper.Map<GetByIdBrandQueryResponse>(brand);

			return response;
		}
	}
}
