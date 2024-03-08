using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Brands.Rules;
using Teknoroma.Application.Services.Brands;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Update
{
	public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBrandService _brandService;
		private readonly BrandBusinessRules _brandBusinessRules;

		public UpdateBrandCommandHandler(IMapper mapper, IBrandService brandService,BrandBusinessRules brandBusinessRules)
		{
			_mapper = mapper;
			_brandService = brandService;
			_brandBusinessRules = brandBusinessRules;
		}

		public async Task<Unit> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandService.GetAsync(x=>x.ID == request.ID);

			//BusinessRules
			await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(brand.BrandName,request.BrandName);
			await _brandBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(brand.PhoneNumber, request.PhoneNumber);

			brand = _mapper.Map(request, brand);

			await _brandService.UpdateAsync(brand);

			return Unit.Value;
		}
	}
}
