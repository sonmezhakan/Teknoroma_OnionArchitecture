using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Brands.Quries.GetList
{
	public class GetAllBrandCommandHandler:IRequestHandler<GetAllBrandCommandRequest,List<GetAllBrandCommandResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public GetAllBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<List<GetAllBrandCommandResponse>> Handle(GetAllBrandCommandRequest request, CancellationToken cancellationToken)
		{
			var brands = await _brandRepository.GetAllAsync();

			List<GetAllBrandCommandResponse> responses = _mapper.Map<List<GetAllBrandCommandResponse>>(brands);

			return responses;
		}
	}
}
