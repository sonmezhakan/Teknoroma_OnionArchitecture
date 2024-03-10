using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Suppliers.Rules;
using Teknoroma.Application.Services.Suppliers;

namespace Teknoroma.Application.Features.Suppliers.Command.Create
{
	public class CreateSupplierCommandHandler:IRequestHandler<CreateSupplierCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierService _supplierService;
		private readonly SupplierBusinessRules _supplierBusinessRules;

		public CreateSupplierCommandHandler(IMapper mapper,ISupplierService supplierService,SupplierBusinessRules supplierBusinessRules)
        {
			_mapper = mapper;
			_supplierService = supplierService;
			_supplierBusinessRules = supplierBusinessRules;
		}

		public async Task<Unit> Handle(CreateSupplierCommandRequest request, CancellationToken cancellationToken)
		{
			//BusinessRules
			await _supplierBusinessRules.PhoneNumberCannotBeDuplicatedWhenInserted(request.PhoneNumber);

			Teknoroma.Domain.Entities.Supplier supplier = _mapper.Map<Teknoroma.Domain.Entities.Supplier>(request);

			await _supplierService.AddAsync(supplier);

			return Unit.Value;
		}
	}
}
