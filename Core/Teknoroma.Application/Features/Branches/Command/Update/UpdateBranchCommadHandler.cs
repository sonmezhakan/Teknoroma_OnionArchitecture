using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Update
{
	public class UpdateBranchCommadHandler : IRequestHandler<UpdateBranchCommandRequest, string>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;

		public UpdateBranchCommadHandler(IMapper mapper, IBranchRepository branchRepository )
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
		}
        public async Task<string> Handle(UpdateBranchCommandRequest request, CancellationToken cancellationToken)
		{
			Branch branch = await _branchRepository.GetAsync(x => x.ID == request.ID);

			branch = _mapper.Map(request, branch);

			await _branchRepository.UpdateAsync(branch);

			return "Güncelleme Başarılı!";
		}
	}
}
