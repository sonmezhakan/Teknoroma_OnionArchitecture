using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;

namespace Teknoroma.Application.Features.Departments.Queries.GetList
{
	public class GetAllDepartmentCommandHandler:IRequestHandler<GetAllDepartmentCommandRequest,List<GetAllDepartmentCommandResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public GetAllDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
		{
			_mapper = mapper;
			_departmentRepository = departmentRepository;
		}

		public async Task<List<GetAllDepartmentCommandResponse>> Handle(GetAllDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			var departments = await _departmentRepository.GetAllAsync();

			List<GetAllDepartmentCommandResponse> responses = _mapper.Map<List<GetAllDepartmentCommandResponse>>(departments);

			return responses;
		}
	}
}
