using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommandRequest,string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category);

            return "Kayıt başarılı!";
        }
    }
}
