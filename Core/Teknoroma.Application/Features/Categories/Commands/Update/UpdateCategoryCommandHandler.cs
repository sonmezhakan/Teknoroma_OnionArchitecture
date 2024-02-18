using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Categories.Rules;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
		private readonly CategoryBusinessRules _categoryBusinessRules;

		public UpdateCategoryCommandHandler(IMapper mapper,ICategoryRepository categoryRepository,CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
			_categoryBusinessRules = categoryBusinessRules;
		}
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(x => x.ID == request.ID);

			//BusinessRuless
			await _categoryBusinessRules.UpdateCategoryNameCannotBeDuplicatedWhenInserted(category.CategoryName,request.CategoryName);

			category = _mapper.Map(request, category);

            await _categoryRepository.UpdateAsync(category);

			return Unit.Value;
		}
    }
}
