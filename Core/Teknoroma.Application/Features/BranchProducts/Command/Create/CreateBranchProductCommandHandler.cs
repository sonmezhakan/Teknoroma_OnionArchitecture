using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.BranchProducts.Command.Create
{
	public class CreateBranchProductCommandHandler : IRequestHandler<CreateBranchProductCommandRequest>
	{
		private readonly IMapper _mapper;
		private readonly IBranchProductRepository _branchProductRepository;

		public CreateBranchProductCommandHandler(IMapper mapper, IBranchProductRepository branchProductRepository)
        {
			_mapper = mapper;
			_branchProductRepository = branchProductRepository;
		}
        public async Task<Unit> Handle(CreateBranchProductCommandRequest request, CancellationToken cancellationToken)
		{
			BranchProduct branchProduct = _mapper.Map<BranchProduct>(request);

			await _branchProductRepository.AddAsync(branchProduct);

			return Unit.Value;
		}
	}
}
