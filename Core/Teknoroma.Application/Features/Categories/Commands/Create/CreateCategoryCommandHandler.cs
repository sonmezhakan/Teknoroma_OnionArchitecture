using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Categories.Rules;
using Teknoroma.Application.Services.Categories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Create
{
	public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		private readonly CategoryBusinessRules _categoryBusinessRules;

		public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
			_categoryService = categoryService;
			_mapper = mapper;
			_categoryBusinessRules = categoryBusinessRules;
		}

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //BusinessRuless
            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenInserted(request.CategoryName);

            Category category = _mapper.Map<Category>(request);

            await _categoryService.AddAsync(category);


			return Unit.Value;
		}
    }
}
