using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddProductToShopList
{
    public class AddProductToShopListCommandHandler : IRequestHandler<AddProductToShopListCommandRequest, AddProductToShopListCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public Task<AddProductToShopListCommandResponse> Handle(AddProductToShopListCommandRequest request, CancellationToken cancellationToken)
        {
            return new AddProductToShopListCommandResponse { IsSuccess=true };
        }
    }
}
