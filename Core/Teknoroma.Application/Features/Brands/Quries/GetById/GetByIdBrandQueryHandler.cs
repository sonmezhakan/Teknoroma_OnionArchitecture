using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Brands;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Quries.GetById
{
	public class GetByIdBrandQueryHandler:IRequestHandler<GetByIdBrandQueryRequest, GetByIdBrandQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBrandService _brandService;

		public GetByIdBrandQueryHandler(IMapper mapper, IBrandService brandService)
		{
			_mapper = mapper;
			_brandService = brandService;
		}

		public async Task<GetByIdBrandQueryResponse> Handle(GetByIdBrandQueryRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandService.GetAsync(x=>x.ID ==  request.ID);

			GetByIdBrandQueryResponse response = _mapper.Map<GetByIdBrandQueryResponse>(brand);

			return response;
		}
	}
}
