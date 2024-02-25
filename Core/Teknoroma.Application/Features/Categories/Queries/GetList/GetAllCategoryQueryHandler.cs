using AutoMapper;
using MediatR;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Categories.Queries.GetList
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            List<GetAllCategoryQueryResponse> categoryDTOs = _mapper.Map<List<GetAllCategoryQueryResponse>>(categories.ToList());

            return categoryDTOs;
        }
    }
}
