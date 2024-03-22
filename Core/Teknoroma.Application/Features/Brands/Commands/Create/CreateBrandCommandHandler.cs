using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Brands.Rules;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Create
{
	public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommandRequest,Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;
		private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IMapper mapper,IBrandRepository brandRepository,BrandBusinessRules brandBusinessRules)
        {
			_mapper = mapper;
			_brandRepository = brandRepository;
			_brandBusinessRules = brandBusinessRules;
        }

		public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.BrandName);
			
			Brand brand = _mapper.Map<Brand>(request);

			await _brandRepository.AddAsync(brand);

			return Unit.Value;
		}
	}
}
