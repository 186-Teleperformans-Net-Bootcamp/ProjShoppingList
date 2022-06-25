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
    public class HardRemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HardRemoveProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var removed = _mapper.Map<Product>(request);
            _ = await _unitOfWork.ProductShopListWriteRepository.HardRemoveByProductIdAsync(request.Id);
            var result = await _unitOfWork.ProductWriteRepository.HardRemoveAsync(removed);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
