using MediatR;
using Teknoroma.Application.Services.Employees;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Command.Delete
{
	public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, Unit>
	{
		private readonly IEmployeeService _employeeService;

		public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
        {
			_employeeService = employeeService;
		}
        public async Task<Unit> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			Employee employee = await _employeeService.GetAsync(x => x.ID == request.ID);

			await _employeeService.DeleteAsync(employee);

			return Unit.Value;
		}
	}
}
