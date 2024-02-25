using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Delete
{
	public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommandRequest, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<Unit> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetAsync(x => x.ID == request.ID);

			await _brandRepository.DeleteAsync(brand);

			return Unit.Value;
		}
	}
}
