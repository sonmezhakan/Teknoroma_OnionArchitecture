using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Categories.Queries.GetById
{
	public class GetByIdCategoryQueryHandler:IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
			_categoryRepository = categoryRepository;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var getCategory = await _categoryRepository.GetAsync(x=>x.ID == request.ID);

            GetByIdCategoryQueryResponse response = _mapper.Map<GetByIdCategoryQueryResponse>(getCategory);

            return response;
        }
    }
}
