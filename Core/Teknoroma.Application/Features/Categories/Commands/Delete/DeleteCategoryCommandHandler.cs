using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Delete
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
		private readonly ICategoryRepository _categoryRepository;

		public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
			_categoryRepository = categoryRepository;
		}

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(x => x.ID == request.ID);

            await _categoryRepository.DeleteAsync(category);

			return Unit.Value;
		}
    }
}
