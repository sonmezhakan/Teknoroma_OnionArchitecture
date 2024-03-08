using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Departments.Rules;
using Teknoroma.Application.Services.Departments;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Update
{
	public class UpdateDepartmentCommandHandler:IRequestHandler<UpdateDepartmentCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentService _departmentService;
		private readonly DepartmentBusinessRules _departmentBusinessRules;

		public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentService departmentService,DepartmentBusinessRules departmentBusinessRules)
		{
			_mapper = mapper;
			_departmentService = departmentService;
			_departmentBusinessRules = departmentBusinessRules;
		}

		public async Task<Unit> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = await _departmentService.GetAsync(x=>x.ID == request.ID);

			//BusinessRules
			await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenUpdated(department.DepartmentName,request.DepartmentName);

			department = _mapper.Map(request, department);

			await _departmentService.UpdateAsync(department);

			return Unit.Value;
		}
	}
}
