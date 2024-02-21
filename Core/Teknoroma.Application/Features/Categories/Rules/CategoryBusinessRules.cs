using Teknoroma.Application.Exceptions.Types;
using Teknoroma.Application.Features.Categories.Constants;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
			_categoryRepository = categoryRepository;
		}
        public async Task CategoryNameCannotBeDuplicatedWhenInserted(string name)
		{
			bool result = await _categoryRepository.AnyAsync(x => x.CategoryName == name);

			if (result)
				throw new BusinessException(CategoryMessages.CategoryNameExists);
		}
		public async Task CategoryNameCannotBeDuplicatedWhenUpdated(string oldCategoryName, string newCategoryName)
		{
			if (oldCategoryName != newCategoryName)
			{
				bool result = await _categoryRepository.AnyAsync(x => x.CategoryName == newCategoryName);

				if (result)
					throw new BusinessException(CategoryMessages.CategoryNameExists);
			}
		}

	}
}
