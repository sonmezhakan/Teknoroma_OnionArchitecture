using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Delete
{
	public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommandRequest, Unit>
	{
		private readonly IBrandRepository _brandRepository;

		public DeleteBrandCommandHandler(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<Unit> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetAsync(x => x.ID == request.ID);

			await _brandRepository.DeleteAsync(brand);

			return Unit.Value;
		}
	}
}
