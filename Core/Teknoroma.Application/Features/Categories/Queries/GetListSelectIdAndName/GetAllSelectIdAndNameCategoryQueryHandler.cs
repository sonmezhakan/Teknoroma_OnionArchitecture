using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameCategoryQueryHandler : IRequestHandler<GetAllSelectIdAndNameCategoryQueryRequest, List<GetAllSelectIdAndNameCategoryQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllSelectIdAndNameCategoryQueryHandler(IMapper mapper,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<GetAllSelectIdAndNameCategoryQueryResponse>> Handle(GetAllSelectIdAndNameCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameCategoryQueryResponse> getAllSelectIdAndNameCategoryQueryResponses = _mapper.Map<List<GetAllSelectIdAndNameCategoryQueryResponse>>(categories.ToList());

            return getAllSelectIdAndNameCategoryQueryResponses;
        }
    }
}
