using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Commands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var removed = _mapper.Map<Category>(request);
            if (removed != null)
            {
                var result=await _unitOfWork.CategoryWriteRepository.SoftRemoveAsync(removed);
                if (result)
                {
                    return new CommandResponse { IsSuccess = true };
                }
                return new CommandResponse { IsSuccess = false };
            }
            return new CommandResponse { IsSuccess = false };
        }
    }
}
