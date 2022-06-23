using Application.Common.Repositories.CategoryRepo;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public AddCategoryCommandHandler(IMapper mapper, ICategoryWriteRepository categoryWriteRepository)
        {
            _mapper = mapper;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var addedCategory=_mapper.Map<Category>(request);
            var result = await _categoryWriteRepository.AddAsync(addedCategory);
            if (result)
            {
                return new AddCategoryCommandResponse { IsSuccess = true };
            }
            else return new AddCategoryCommandResponse { IsSuccess = false };
        }
    }
}
