using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Employees;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Command.Update
{
	public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeService _employeeService;

		public UpdateEmployeeCommandHandler(IMapper mapper,IEmployeeService employeeService)
        {
			_mapper = mapper;
			_employeeService = employeeService;
		}
        public async Task<Unit> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			Employee employee = await _employeeService.GetAsync(x => x.ID == request.ID);

			employee = _mapper.Map(request, employee);

			await _employeeService.UpdateAsync(employee);

			return Unit.Value;
		}
	}
}
