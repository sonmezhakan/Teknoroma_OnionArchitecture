using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Employees.Command.Update
{
	public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeRepository _employeeRepository;

		public UpdateEmployeeCommandHandler(IMapper mapper,IEmployeeRepository employeeRepository)
        {
			_mapper = mapper;
			_employeeRepository = employeeRepository;
		}
        public async Task<Unit> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			Employee employee = await _employeeRepository.GetFullSearch(x => x.ID == request.ID);

			employee = _mapper.Map(request, employee);

			await _employeeRepository.UpdateAsync(employee);

			return Unit.Value;
		}
	}
}
