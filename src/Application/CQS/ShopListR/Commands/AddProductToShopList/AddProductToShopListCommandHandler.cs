using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
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

        public AddProductToShopListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddProductToShopListCommandResponse> Handle(AddProductToShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var added = _mapper.Map<ProductShopList>(request);
            var result = await _unitOfWork.ProductShopListWriteRepository.AddAsync(added);
            if (result)
            {
                return new AddProductToShopListCommandResponse { IsSuccess = true };
            }
            else return new AddProductToShopListCommandResponse { IsSuccess = false };
        }
    }
}
