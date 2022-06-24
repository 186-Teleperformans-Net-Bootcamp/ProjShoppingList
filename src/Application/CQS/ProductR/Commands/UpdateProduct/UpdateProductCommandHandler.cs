using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct=_mapper.Map<Product>(request);
            var result = await _unitOfWork.ProductWriteRepository.UpdateProductAsync(updatedProduct);
            if (result) return new CommandResponse { IsSuccess = true };
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
