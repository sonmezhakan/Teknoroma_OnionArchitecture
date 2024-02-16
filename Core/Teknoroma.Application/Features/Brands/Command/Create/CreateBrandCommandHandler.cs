using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Create
{
	public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public CreateBrandCommandHandler(IMapper mapper,IBrandRepository brandRepository)
        {
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<string> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = _mapper.Map<Brand>(request);

			await _brandRepository.AddAsync(brand);

			return "Kayıt Başarılı!";
		}
	}
}
