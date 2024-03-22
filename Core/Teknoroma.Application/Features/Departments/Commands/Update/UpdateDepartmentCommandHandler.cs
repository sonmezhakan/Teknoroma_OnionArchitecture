using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Departments.Rules;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Update
{
	public class UpdateDepartmentCommandHandler:IRequestHandler<UpdateDepartmentCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;
		private readonly DepartmentBusinessRules _departmentBusinessRules;

		public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository,DepartmentBusinessRules departmentBusinessRules)
		{
			_mapper = mapper;
			_departmentRepository = departmentRepository;
			_departmentBusinessRules = departmentBusinessRules;
		}

		public async Task<Unit> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = await _departmentRepository.GetAsync(x=>x.ID == request.ID);

			//BusinessRules
			await _departmentBusinessRules.DepartmentNameCannotBeDuplicatedWhenUpdated(department.DepartmentName,request.DepartmentName);

			department = _mapper.Map(request, department);

			await _departmentRepository.UpdateAsync(department);

			return Unit.Value;
		}
	}
}
