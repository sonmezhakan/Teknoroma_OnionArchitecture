using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Suppliers.Rules;
using Teknoroma.Application.Services.Suppliers;

namespace Teknoroma.Application.Features.Suppliers.Command.Update
{
	public class UpdateSupplierCommandHandler:IRequestHandler<UpdateSupplierCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierService _supplierService;
		private readonly SupplierBusinessRules _supplierBusinessRules;

		public UpdateSupplierCommandHandler(IMapper mapper,ISupplierService supplierService, SupplierBusinessRules supplierBusinessRules)
        {
			_mapper = mapper;
			_supplierService = supplierService;
			_supplierBusinessRules = supplierBusinessRules;
		}

		public async Task<Unit> Handle(UpdateSupplierCommandRequest request, CancellationToken cancellationToken)
		{
			Teknoroma.Domain.Entities.Supplier supplier = await _supplierService.GetAsync(x => x.ID == request.ID);

			//BusinessRules
			await _supplierBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(supplier.PhoneNumber,request.PhoneNumber);

			supplier = _mapper.Map(request, supplier);

			await _supplierService.UpdateAsync(supplier);

			return Unit.Value;
		}
	}
}
