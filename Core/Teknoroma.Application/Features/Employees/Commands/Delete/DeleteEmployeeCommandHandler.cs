using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Command.Delete
{
	public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, Unit>
	{
		private readonly IEmployeeRepository _employeeRepository;

		public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
			_employeeRepository = employeeRepository;
		}
        public async Task<Unit> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			Employee employee = await _employeeRepository.GetAsync(x => x.ID == request.ID);

			await _employeeRepository.DeleteAsync(employee);

			return Unit.Value;
		}
	}
}
