using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Categories;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Categories.Queries.GetById
{
	public class GetByIdCategoryQueryHandler:IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;

        public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
			_categoryService = categoryService;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var getCategory = await _categoryService.GetAsync(x=>x.ID == request.ID);

            GetByIdCategoryQueryResponse response = _mapper.Map<GetByIdCategoryQueryResponse>(getCategory);

            return response;
        }
    }
}
