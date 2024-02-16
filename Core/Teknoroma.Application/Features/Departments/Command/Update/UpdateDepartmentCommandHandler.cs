using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Departments.Command.Update
{
	public class UpdateDepartmentCommandHandler:IRequestHandler<UpdateDepartmentCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentRepository _departmentRepository;

		public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
		{
			_mapper = mapper;
			_departmentRepository = departmentRepository;
		}

		public async Task<string> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
		{
			Department department = await _departmentRepository.GetAsync(x=>x.ID == request.ID);

			department = _mapper.Map(request, department);

			await _departmentRepository.UpdateAsync(department);

			return "Güncelleme Başarılı!";
		}
	}
}
