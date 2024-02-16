using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Brands.Command.Update
{
	public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommandRequest,string>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<string> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetAsync(x=>x.ID == request.ID);

			brand = _mapper.Map(request, brand);

			await _brandRepository.UpdateAsync(brand);

			return "Güncelleme Başarılı!";
		}
	}
}
