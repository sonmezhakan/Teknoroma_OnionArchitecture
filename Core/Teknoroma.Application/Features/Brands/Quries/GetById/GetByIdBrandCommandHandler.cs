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
	public class GetByIdBrandCommandHandler:IRequestHandler<GetByIdBrandCommandRequest, GetByIdBrandCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public GetByIdBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<GetByIdBrandCommandResponse> Handle(GetByIdBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetAsync(x=>x.ID ==  request.ID);

			GetByIdBrandCommandResponse response = _mapper.Map<GetByIdBrandCommandResponse>(brand);

			return response;
		}
	}
}
