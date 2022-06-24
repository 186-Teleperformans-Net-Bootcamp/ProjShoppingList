using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddShopList
{
    public class AddShopListCommandHandler : IRequestHandler<AddShopListCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<CommandResponse> Handle(AddShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var added = _mapper.Map<ShopList>(request);
            var result = await _unitOfWork.ShopListWriteRepository.AddAsync(added);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
