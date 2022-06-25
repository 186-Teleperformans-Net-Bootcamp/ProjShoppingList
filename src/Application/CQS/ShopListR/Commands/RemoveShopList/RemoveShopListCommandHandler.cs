using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.RemoveShopList
{
    public class RemoveShopListCommandHandler : IRequestHandler<RemoveShopListCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveShopListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<CommandResponse> Handle(RemoveShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var removed=_mapper.Map<ShopList>(request);
            _ = await _unitOfWork.ProductShopListWriteRepository.SoftRemoveByShopListIdAsync(request.Id);
            var result=await _unitOfWork.ShopListWriteRepository.SoftRemoveAsync(removed);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
