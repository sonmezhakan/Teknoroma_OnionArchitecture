using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Delete
{
	public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommandRequest, string>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;

		public DeleteBranchCommandHandler(IMapper mapper,IBranchRepository branchRepository)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
		}
        public async Task<string> Handle(DeleteBranchCommandRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchRepository.GetAsync(x=>x.ID == request.ID);

			await _branchRepository.DeleteAsync(branch);

			return "Kalıcı Olarak Silindi!";
		}
	}
}
