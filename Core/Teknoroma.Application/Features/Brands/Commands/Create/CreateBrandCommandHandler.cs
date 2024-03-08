using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Brands.Rules;
using Teknoroma.Application.Services.Brands;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Create
{
	public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommandRequest,Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBrandService _brandService;
		private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IMapper mapper,IBrandService brandService,BrandBusinessRules brandBusinessRules)
        {
			_mapper = mapper;
			_brandService = brandService;
			_brandBusinessRules = brandBusinessRules;
        }

		public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.BrandName);
			
			Brand brand = _mapper.Map<Brand>(request);

			await _brandService.AddAsync(brand);

			return Unit.Value;
		}
	}
}
