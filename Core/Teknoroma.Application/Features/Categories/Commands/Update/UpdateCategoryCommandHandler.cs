using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Categories.Rules;
using Teknoroma.Application.Services.Categories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Update
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;
		private readonly CategoryBusinessRules _categoryBusinessRules;

		public UpdateCategoryCommandHandler(IMapper mapper,ICategoryService categoryService,CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
			_categoryService = categoryService;
			_categoryBusinessRules = categoryBusinessRules;
		}
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryService.GetAsync(x => x.ID == request.ID);

			//BusinessRuless
			await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(category.CategoryName,request.CategoryName);

			category = _mapper.Map(request, category);

            await _categoryService.UpdateAsync(category);

			return Unit.Value;
		}
    }
}
