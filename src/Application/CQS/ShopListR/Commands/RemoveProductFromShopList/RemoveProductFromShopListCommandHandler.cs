using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.RemoveProductFromShopList
{
    public class RemoveProductFromShopListCommandHandler : IRequestHandler<RemoveProductFromShopListCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<CommandResponse> Handle(RemoveProductFromShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var removed = _mapper.Map<ProductShopList>(request);
            var result = await _unitOfWork.ProductShopListWriteRepository.RemoveAsync(removed);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
