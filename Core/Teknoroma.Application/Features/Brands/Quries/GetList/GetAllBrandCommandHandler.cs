using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Brands;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Brands.Quries.GetList
{
    public class GetAllBrandCommandHandler:IRequestHandler<GetAllBrandCommandRequest,List<GetAllBrandCommandResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IBrandService _brandService;

		public GetAllBrandCommandHandler(IMapper mapper, IBrandService brandService)
		{
			_mapper = mapper;
			_brandService = brandService;
		}

		public async Task<List<GetAllBrandCommandResponse>> Handle(GetAllBrandCommandRequest request, CancellationToken cancellationToken)
		{
			var brands = await _brandService.GetAllAsync();

			List<GetAllBrandCommandResponse> responses = _mapper.Map<List<GetAllBrandCommandResponse>>(brands.ToList());

			return responses;
		}
	}
}
