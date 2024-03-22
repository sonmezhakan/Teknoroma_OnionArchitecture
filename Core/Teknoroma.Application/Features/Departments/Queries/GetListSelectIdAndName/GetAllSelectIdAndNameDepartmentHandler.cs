using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Departments.Queries.GetListSelectIdAndName
{
    public class GetAllSelectIdAndNameDepartmentHandler : IRequestHandler<GetAllSelectIdAndNameDepartmentRequest, List<GetAllSelectIdAndNameDepartmentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllSelectIdAndNameDepartmentHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }
        public async Task<List<GetAllSelectIdAndNameDepartmentResponse>> Handle(GetAllSelectIdAndNameDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllSelectIdAndNameAsync();

            List<GetAllSelectIdAndNameDepartmentResponse> getAllSelectIdAndNameDepartmentResponses = _mapper.Map<List<GetAllSelectIdAndNameDepartmentResponse>>(departments.ToList());

            return getAllSelectIdAndNameDepartmentResponses;
        }
    }
}
