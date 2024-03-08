using MediatR;
using Teknoroma.Application.Services.Brands;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Delete
{
	public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommandRequest, Unit>
	{
		private readonly IBrandService _brandService;

		public DeleteBrandCommandHandler(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public async Task<Unit> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandService.GetAsync(x => x.ID == request.ID);

			await _brandService.DeleteAsync(brand);

			return Unit.Value;
		}
	}
}
