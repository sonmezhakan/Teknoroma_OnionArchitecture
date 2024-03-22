using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Brands.Rules;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Update
{
	public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;
		private readonly BrandBusinessRules _brandBusinessRules;

		public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository,BrandBusinessRules brandBusinessRules)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
			_brandBusinessRules = brandBusinessRules;
		}

		public async Task<Unit> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetAsync(x=>x.ID == request.ID);

			//BusinessRules
			await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(brand.BrandName,request.BrandName);
			await _brandBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(brand.PhoneNumber, request.PhoneNumber);

			brand = _mapper.Map(request, brand);

			await _brandRepository.UpdateAsync(brand);

			return Unit.Value;
		}
	}
}
