using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Categories;

namespace Teknoroma.Application.Features.Categories.Queries.GetList
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
			_categoryService = categoryService;
			_mapper = mapper;
        }

        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllAsync();

            List<GetAllCategoryQueryResponse> categoryDTOs = _mapper.Map<List<GetAllCategoryQueryResponse>>(categories.ToList());

            return categoryDTOs;
        }
    }
}
