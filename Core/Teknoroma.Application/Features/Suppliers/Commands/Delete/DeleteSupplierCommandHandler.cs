﻿using AutoMapper;
using MediatR;
using Teknoroma.Application.Services.Suppliers;

namespace Teknoroma.Application.Features.Suppliers.Command.Delete
{

	public class DeleteSupplierCommandHandler:IRequestHandler<DeleteSupplierCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISupplierService _supplierService;

		public DeleteSupplierCommandHandler(IMapper mapper,ISupplierService supplierService )
		{
			_mapper = mapper;
			_supplierService = supplierService;
		}

		public async Task<Unit> Handle(DeleteSupplierCommandRequest request, CancellationToken cancellationToken)
		{
			Teknoroma.Domain.Entities.Supplier supplier = _mapper.Map<Teknoroma.Domain.Entities.Supplier>(request);

			await _supplierService.DeleteAsync(supplier);

			return Unit.Value;
		}
	}
}
