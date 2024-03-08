using MediatR;
using Teknoroma.Application.Services.Categories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Delete
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
		private readonly ICategoryService _categoryService;

		public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
			_categoryService = categoryService;
		}

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryService.GetAsync(x => x.ID == request.ID);

            await _categoryService.DeleteAsync(category);

			return Unit.Value;
		}
    }
}
