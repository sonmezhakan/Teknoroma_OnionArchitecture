using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Repositories;

namespace Teknoroma.Application.Features.Suppliers.Command.Delete
{

	public class DeleteSupplierCommandHandler:IRequestHandler<DeleteSupplierCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierRepository _supplierRepository;

		public DeleteSupplierCommandHandler(IMapper mapper,ISupplierRepository supplierRepository )
		{
			_mapper = mapper;
			_supplierRepository = supplierRepository;
		}

		public async Task<Unit> Handle(DeleteSupplierCommandRequest request, CancellationToken cancellationToken)
		{
			Teknoroma.Domain.Entities.Supplier supplier = await _supplierRepository.GetAsync(x=>x.ID == request.ID);

			await _supplierRepository.DeleteAsync(supplier);

			return Unit.Value;
		}
	}
}
