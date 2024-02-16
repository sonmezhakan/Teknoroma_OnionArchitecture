using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, string>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<string> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(x => x.ID == request.ID);

            category = _mapper.Map(request, category);

            await _categoryRepository.UpdateAsync(category);

            return "Güncelleme Başarılı!";
        }
    }
}
