using AutoMapper;
using MediatR;
using Teknoroma.Application.Features.Suppliers.Rules;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Command.Update
{
    public class UpdateSupplierCommandHandler:IRequestHandler<UpdateSupplierCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierRepository _supplierRepository;
		private readonly SupplierBusinessRules _supplierBusinessRules;

		public UpdateSupplierCommandHandler(IMapper mapper,ISupplierRepository supplierRepository, SupplierBusinessRules supplierBusinessRules)
        {
			_mapper = mapper;
			_supplierRepository = supplierRepository;
			_supplierBusinessRules = supplierBusinessRules;
		}

		public async Task<Unit> Handle(UpdateSupplierCommandRequest request, CancellationToken cancellationToken)
		{
			Teknoroma.Domain.Entities.Supplier supplier = await _supplierRepository.GetAsync(x => x.ID == request.ID);

			//BusinessRules
			await _supplierBusinessRules.PhoneNumberCannotBeDuplicatedWhenUpdated(supplier.PhoneNumber,request.PhoneNumber);

			supplier = _mapper.Map(request, supplier);

			await _supplierRepository.UpdateAsync(supplier);

			return Unit.Value;
		}
	}
}
