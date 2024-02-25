using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Branches.Rules;
using Teknoroma.Application.Features.Products.Queries.GetList;
using Teknoroma.Application.Features.Stocks.Command.Create;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Branches.Command.Create
{
	public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;
		private readonly BranchBusinessRules _branchBusinessRules;
		private readonly IMediator _mediator;

		public CreateBranchCommandHandler(IMapper mapper,IBranchRepository branchRepository,BranchBusinessRules branchBusinessRules,IMediator mediator)
        {
			_mapper = mapper;
			_branchRepository = branchRepository;
			_branchBusinessRules = branchBusinessRules;
			_mediator = mediator;
		}
		public async Task<Unit> Handle(CreateBranchCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinesRules
			await _branchBusinessRules.BranchNameCannotBeDuplicatedWhenInserted(request.BranchName);
			await _branchBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);

			Branch branch = _mapper.Map<Branch>(request);

			await _branchRepository.AddAsync(branch);

			//Yeni eklenen şubeye tüm ürünler ekleniyor
			var products = await _mediator.Send(new GetAllProductQueryRequest());

			foreach (var product in products)
			{
				CreateStockCommandRequest createStockCommandRequest = new CreateStockCommandRequest
				{
					BranchId = branch.ID,
					ProductId = product.ID,
					UnitsInStock = 0,
				};
				await _mediator.Send(createStockCommandRequest);
			}

			return Unit.Value;
		}
	}
}
