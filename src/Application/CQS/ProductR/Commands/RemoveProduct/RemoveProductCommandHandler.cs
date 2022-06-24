using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //If any basket contains this product?
        public async Task<CommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var removed = _mapper.Map<Product>(request);
            var result=await _unitOfWork.ProductWriteRepository.RemoveAsync(removed);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
